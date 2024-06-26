using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [Route("error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        _logger.LogError("Error occured: {message} with stack trace: {stackTrace}", exception?.Message,
            exception?.StackTrace);

        return Problem(title: exception?.Message, statusCode: 400);
    }
}