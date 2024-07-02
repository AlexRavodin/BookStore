using System.Security.Claims;
using BookStore.Api.Helpers;
using BookStore.Api.Services.Images;
using BookStore.Api.Validation.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/images")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    [Route("user")]
    public async Task<IActionResult> Post(IFormFile image)
    {
        if (!image.ValidateFile())
        {
            return ValidationProblem("File has wrong extension or too big.");
        }

        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
        {
            return BadRequest("User is not logged in.");
        }
        
        if (!Guid.TryParse(userId, out var guidUserId))
        {
            return BadRequest("Bad user id.");
        }
        
        await _imageService.AddImageToUser(image, guidUserId);
        
        return Ok();
    }
    
    [HttpPost]
    [Route("book/{bookId:int}")]
    public async Task<IActionResult> Post(IFormFile image, int bookId)
    {
        if (!image.ValidateFile())
        {
            return ValidationProblem("File has wrong extension or too big.");
        }
        
        await _imageService.AddImageToBook(image, bookId);
        
        return Ok();
    }
}


