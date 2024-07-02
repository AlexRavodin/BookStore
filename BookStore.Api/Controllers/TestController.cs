using BookStore.Api.Models.Books.Request;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpPost]
    public IActionResult Update(UpdateBookRequest updateBookRequest)
    {
        
        return Ok();
    }
}