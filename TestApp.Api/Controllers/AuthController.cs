using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;
using TestApp.Api.Helpers;
using TestApp.Api.Models;
using TestApp.Api.Models.Dto;
using TestApp.Api.Models.Requests;

namespace TestApp.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;
    
    private readonly UserManager<IdentityUser> _userManager;
    
    public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    /*[HttpGet]
    [Route("users")]
    [Authorize]
    public IActionResult Users([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;
        var claims = user?.Claims.ToDictionary(x => x.Type, x => x.Value);
        return Ok(claims);
    }*/
    
    [HttpGet]
    [Route("user/{userId}")]
    //[Authorize]
    public async Task<IActionResult> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        
        if (user is null)
        {
            return BadRequest("User doest not exist.");
        }
        
        var claims = await _userManager.GetClaimsAsync(user);

        var result = claims.ToDictionary(x => x.Type, x => x.Value);
        result["id"] = userId;
        result["name"] = user.UserName ?? "";
        
        
        return Ok(result);
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(loginRequest.Username, 
            loginRequest.Password, true, false);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest.Password != registerRequest.ConfirmPassword)
        {
            return BadRequest();
        }

        var user = new IdentityUser
        {
            UserName = registerRequest.Username,
        };

        var createResult = await _userManager.CreateAsync(user, registerRequest.Password);
        if (!createResult.Succeeded)
        {
            return BadRequest(createResult.Errors);
        }

        await _signInManager.SignInAsync(user, true);
        
        return Ok();
    }
    
    [HttpGet]
    [Route("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        
        return Ok();
    }
    
    [HttpGet]
    [Route("users")]
    [Authorize(Policy = Constants.Admin)]
    public async Task<IActionResult> GetUsers()
    {
        List<UserListItem> users = new();
        
        users.AddRange(await GetUsersWithSameRole(Constants.Admin));
        users.AddRange(await GetUsersWithSameRole(Constants.Moderator));
        users.AddRange(await GetUsersWithSameRole(Constants.Customer));

        
        return Ok(users);
    }

    private async Task<List<UserListItem>> GetUsersWithSameRole(string claimName)
    {
        return (await _userManager.GetUsersForClaimAsync(new Claim("level", claimName))).Select(u =>
            new UserListItem(u.Id, u.UserName ?? "", claimName)).ToList();
    }
    
    [HttpGet]
    [Route("change-role/{userId:guid}/{claimName}")]
    [Authorize(Policy = Constants.Admin)]
    public async Task<IActionResult> UpdateRole(Guid userId, string claimName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user is null)
        {
            return BadRequest("User doest not exist.");
        }
        
        var claims = await _userManager.GetClaimsAsync(user);
        
        await _userManager.RemoveClaimsAsync(user, claims);
        await _userManager.AddClaimAsync(user, new Claim("level", claimName));
        
        return Ok();
    }
    
}