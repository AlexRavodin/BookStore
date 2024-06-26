using BookStore.Api.Helpers;
using BookStore.Api.Models.Auth.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

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

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(loginRequest.Username,
            loginRequest.Password, true, false);

        if (signInResult.Succeeded)
        {
            var claim = User.Claims.First(c => c.Type == Constants.ClaimTypeName);

            var claimObject = new
            {
                Claim = claim.Value,
            };

            return Ok(claimObject);
        }

        return BadRequest("Can not login.");
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest.Password != registerRequest.ConfirmPassword)
        {
            return BadRequest("Password and confirm password are not same.");
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

        var claim = User.Claims.First(c => c.Type == Constants.ClaimTypeName);

        var claimObject = new
        {
            Claim = claim.Value,
        };

        return Ok(claimObject);
    }

    [HttpGet]
    [Route("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok();
    }
}