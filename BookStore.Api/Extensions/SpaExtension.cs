using BookStore.Api.Middleware;

namespace BookStore.Api.Extensions;

public static class SpaExtension
{
    public static WebApplication BuildWithSpa(this WebApplicationBuilder builder)
    {
        var app = builder.Build();
        
        app.UseMiddleware<RequestContextLoggingMiddleware>();

        //app.UseCors(Constants.CorsPolicy);
        app.UseExceptionHandler("/error");
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(_ => { });
        app.MapDefaultControllerRoute();

        app.UseSpa(x => x.UseProxyToSpaDevelopmentServer("http://localhost:3000"));

        return app;
    }
}