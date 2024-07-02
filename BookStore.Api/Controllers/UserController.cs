using System.Security.Claims;
using BookStore.Api.Helpers;
using BookStore.Api.Models.Users.Request;
using BookStore.Api.Models.Users.Response;
using BookStore.Api.Services.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly IImageService _imageService;

    public UserController(UserManager<IdentityUser> userManager, IImageService imageService)
    {
        _userManager = userManager;
        _imageService = imageService;
    }

    [HttpGet]
    [Authorize(Policy = Constants.Admin)]
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
    [Authorize(Policy = Constants.Admin)]
    public async Task<IActionResult> Get(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        var claims = await _userManager.GetClaimsAsync(user);
        var imagePath = await _imageService.GetUserImagePath(userId);

        var userDetails = new AdminUserDetails(userId, user.UserName ?? "", claims.First().ToString(), imagePath);

        return Ok(userDetails);
    }
    
    [HttpGet]
    [Route("current")]
    public async Task<IActionResult> GetCurrent()
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            return BadRequest("User is not logged in.");
        }
        
        if (!Guid.TryParse(userId, out var guidUserId))
        {
            return BadRequest("Bad user id.");
        }
  
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
        {
            return BadRequest("User does not exist.");
        }
        
        var imagePath = await _imageService.GetUserImagePath(guidUserId);

        var userDetails = new UserDetails(guidUserId, user.UserName ?? "", imagePath);

        return Ok(userDetails);
    }

    [HttpPost]
    [Route("change-role")]
    [Authorize(Policy = Constants.Admin)]
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
    [Authorize(Policy = Constants.Admin)]
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
    [Route("/current")]
    [Authorize]
    public async Task<IActionResult> DeleteCurrent()
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            return BadRequest("User is not logged in.");
        }
        
        if (!Guid.TryParse(userId, out var guidUserId))
        {
            return BadRequest("Bad user id.");
        }
  
        var user = await _userManager.FindByIdAsync(userId);
        
        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        var deleteResult = await _userManager.DeleteAsync(user);
        
        if (!deleteResult.Succeeded)
        {
            return BadRequest(deleteResult.Errors);
        }
        
        await _imageService.RemoveImageFromUser(guidUserId);
        return Ok();
    }
    
    [HttpPost]
    [Route("/current")]
    [Authorize]
    public async Task<IActionResult> UpdateCurrent(UpdateUserRequest updateUserRequest)
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            return BadRequest("User is not logged in.");
        }
        
        if (!Guid.TryParse(userId, out var guidUserId))
        {
            return BadRequest("Bad user id.");
        }
  
        var user = await _userManager.FindByIdAsync(userId);
        
        if (user is null)
        {
            return BadRequest("User does not exist.");
        }

        user.UserName = updateUserRequest.NewName;
        
        var updateResult = await _userManager.UpdateAsync(user);
        
        if (!updateResult.Succeeded)
        {
            return BadRequest(updateResult.Errors);
        }
        
        return Ok();
    }
    
    [HttpDelete]
    [Route("{userId:guid}")]
    [Authorize(Policy = Constants.Admin)]
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

        await _imageService.RemoveImageFromUser(userId);
        
        return Ok();
    }
}