using System.Security.Claims;
using BookStore.Api.Helpers;
using BookStore.Api.Services.Images;
using BookStore.Api.Validation.Image;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/images")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    
    private IValidator<IFormFile> _validator;

    public ImageController(IImageService imageService, IValidator<IFormFile> validator)
    {
        _imageService = imageService;
        _validator = validator;
    }

    [HttpPost]
    [Route("user")]
    public async Task<IActionResult> Post(IFormFile image)
    {
        var validationResult = await _validator.ValidateAsync(image);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToDictionary());
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
        var validationResult = await _validator.ValidateAsync(image);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToDictionary());
        }
        
        await _imageService.AddImageToBook(image, bookId);
        
        return Ok();
    }
}


