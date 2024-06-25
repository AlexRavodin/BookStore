using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TestApp.Api.Helpers;

namespace TestApp.Api.Extensions;

public static class SpaExtension
{
    public static WebApplication BuildWithSpa(this WebApplicationBuilder builder)
    {
        var app = builder.Build();
        
        //app.UseCors("AllowAll");
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(e => { });
        app.MapDefaultControllerRoute();
        
        /*app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });*/
        
        app.UseSpa(x => x.UseProxyToSpaDevelopmentServer("http://localhost:3000"));

        var scope = app.Services.CreateScope();
        
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        if (!userManager.Users.Any(u => u.UserName == "admin"))
        {
            var adminUser = new IdentityUser { UserName = "adm" };

            userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
            userManager.AddClaimAsync(adminUser, new Claim("level", Constants.Admin)).GetAwaiter().GetResult();
        }

        var customerUser = new IdentityUser { UserName = "cust" };

        userManager.CreateAsync(customerUser, "password").GetAwaiter().GetResult();
        userManager.AddClaimAsync(customerUser, new Claim("level", Constants.Customer)).GetAwaiter().GetResult();
        
        var moderatorUser = new IdentityUser { UserName = "moder" };

        userManager.CreateAsync(moderatorUser, "password").GetAwaiter().GetResult();
        userManager.AddClaimAsync(moderatorUser, new Claim("level", Constants.Moderator)).GetAwaiter().GetResult();
        
        
        return app;
    }
}