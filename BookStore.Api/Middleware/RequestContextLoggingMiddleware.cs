using BookStore.Api.Helpers;
using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace BookStore.Api.Middleware;

public class RequestContextLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestContextLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        string correlationId = GetCorrelationId(context);

        using (LogContext.PushProperty(Constants.CorrelationLogIdProperty, correlationId))
        {
            return _next.Invoke(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            Constants.CorrelationLogIdProperty, out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier;
    }

}