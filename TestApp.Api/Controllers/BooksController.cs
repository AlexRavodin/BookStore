using System.Text.Json;
using BookStoreTest.Api.Services.Books;
using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Helpers;

namespace TestApp.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]BookParameters parameters)
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
    public async Task<IActionResult> Get(int id)
    {
        var book = await _bookService.GetBookById(id);
        
        return Ok(book);
    }
    
    [Route("{id:int}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookService.GetBookById(id);
        
        return Ok(book);
    }
}