using System.Text.Json;
using BookStore.Api.Helpers;
using BookStore.Api.Models.Books.Request;
using BookStore.Api.Services.Authors;
using BookStore.Api.Services.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/authors")]
[Authorize]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var authorsDto = await _authorService.GetAuthors();

        return Ok(authorsDto);
    }
}