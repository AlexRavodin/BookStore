using System.Text.Json;
using BookStore.Api.Helpers;
using BookStore.Api.Models.Books.Request;
using BookStore.Api.Services.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/books")]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Authorize(Policy = Constants.Customer)]
    public async Task<IActionResult> Get([FromQuery] BookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pagedBooks = await _bookService.GetBooks(parameters);

        var pagingData = new
        {
            pagedBooks.TotalPages,
        };

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagingData));

        return Ok(pagedBooks);
    }

    
    [Route("{id:int}")]
    [HttpGet]
    [Authorize(Policy = Constants.Customer)]
    public async Task<IActionResult> Get(int id)
    {
        var book = await _bookService.GetBookById(id);

        return Ok(book);
    }
    
    [HttpPut]
    [Authorize(Policy = Constants.Moderator)]
    public async Task<IActionResult> Update(UpdateBookRequest updateBookRequest)
    {
        var book = await _bookService.UpdateBook(updateBookRequest);

        return Ok(book);
    }

    [Route("{id:int}")]
    [HttpDelete]
    [Authorize(Policy = Constants.Moderator)]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookService.DeleteBook(id);

        return Ok();
    }
}