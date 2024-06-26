using System.Security.Claims;
using BookStore.Api.Helpers;
using BookStore.Api.Models.Users.Request;
using BookStore.Api.Models.Users.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Controllers;

[ApiController]
[Authorize(Policy = Constants.Admin)]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<UserListItem> users = [];

        users.AddRange(await GetUsersWithSameClaim(Constants.Admin));
        users.AddRange(await GetUsersWithSameClaim(Constants.Moderator));
        users.AddRange(await GetUsersWithSameClaim(Constants.Customer));

        return Ok(users);
    }

    private async Task<List<UserListItem>> GetUsersWithSameClaim(string claimName)
    {
        var user = await _userManager.Users.ToListAsync();
        
        return (await _userManager.GetUsersForClaimAsync(new Claim(Constants.ClaimTypeName, claimName))).Select(u =>
            new UserListItem(u.Id, u.UserName ?? "", claimName)).ToList();
    }

    [HttpGet]
    [Route("{userId:guid}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        var claims = await _userManager.GetClaimsAsync(user);

        var userDetails = new UserDetails(userId, user.UserName ?? "", claims.First().ToString());

        return Ok(userDetails);
    }

    [HttpPost]
    [Route("change-role")]
    public async Task<IActionResult> UpdateRole(UpdateRoleRequest updateRoleRequest)
    {
        var user = await _userManager.FindByIdAsync(updateRoleRequest.UserId.ToString());
        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        var claims = await _userManager.GetClaimsAsync(user);

        await _userManager.RemoveClaimsAsync(user, claims);
        await _userManager.AddClaimAsync(user, new Claim(Constants.ClaimTypeName, updateRoleRequest.NewRoleName));

        return Ok();
    }

    [HttpPost]
    [Route("change-password")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
    {
        var user = await _userManager.FindByIdAsync(updatePasswordRequest.UserId.ToString());
        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var updateResult =
            await _userManager.ResetPasswordAsync(user, passwordToken, updatePasswordRequest.NewPassword);

        if (!updateResult.Succeeded)
        {
            return BadRequest(updateResult.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    [Route("/{userId:guid}")]
    public async Task<IActionResult> Delete(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        var deleteResult = await _userManager.DeleteAsync(user);

        if (!deleteResult.Succeeded)
        {
            return BadRequest(deleteResult.Errors);
        }

        return Ok();
    }
}