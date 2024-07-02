using System.Security.Claims;
using BookStore.Api.Helpers;
using BookStore.Api.Models.Carts.Request;
using BookStore.Api.Services.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Authorize(Policy = Constants.Customer)]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;

    private readonly UserManager<IdentityUser> _userManager;

    private readonly ICartService _cartService;

    public CartController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
        ICartService cartService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
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

        var cart = await _cartService.GetCart(guidUserId);

        return Ok(cart);
    }

    [HttpPut]
    [Route("{bookId:int}")]
    public async Task<IActionResult> Update(int bookId)
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

        var cart = await _cartService.AddToCart(new AddToCartRequest(guidUserId, bookId));

        return Ok(cart);
    }

    [HttpPost]
    [Route("change-count")]
    public async Task<IActionResult> Update(UpdateCartItemCountRequest updateCartItemCountRequest)
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

        var updateCartRequest = updateCartItemCountRequest with 
        { 
            UserId = guidUserId,
        };
        
        var cart = await _cartService.UpdateCart(updateCartRequest);

        return Ok(cart);
    }
}