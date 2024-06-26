using System.Security.Claims;
using BookStore.Api.Helpers;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Api.Extensions;

public static class DefaultUserSeedingExtension
{
    public static WebApplication SeedDefaultUsers(this WebApplication app)
    {
        var scope = app.Services.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        if (!userManager.Users.Any(u => u.UserName == "admin"))
        {
            var adminUser = new IdentityUser { UserName = "admin" };

            userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
            userManager.AddClaimAsync(adminUser, new Claim(Constants.ClaimTypeName, Constants.Admin)).GetAwaiter()
                .GetResult();
        }

        if (!userManager.Users.Any(u => u.UserName == "cust"))
        {
            var customerUser = new IdentityUser { UserName = "cust" };

            userManager.CreateAsync(customerUser, "password").GetAwaiter().GetResult();
            userManager.AddClaimAsync(customerUser, new Claim(Constants.ClaimTypeName, Constants.Customer)).GetAwaiter()
                .GetResult();
        }

        if (!userManager.Users.Any(u => u.UserName == "moder"))
        {
            var moderatorUser = new IdentityUser { UserName = "moder" };

            userManager.CreateAsync(moderatorUser, "password").GetAwaiter().GetResult();
            userManager.AddClaimAsync(moderatorUser, new Claim(Constants.ClaimTypeName, Constants.Moderator))
                .GetAwaiter().GetResult();
        }

        if (!userManager.Users.Any(u => u.UserName == "1"))
        {
            var basicAdmin = new IdentityUser { UserName = "1" };

            userManager.CreateAsync(basicAdmin, "1").GetAwaiter().GetResult();
            userManager.AddClaimAsync(basicAdmin, new Claim(Constants.ClaimTypeName, Constants.Admin)).GetAwaiter()
                .GetResult();
        }
        
        if (!userManager.Users.Any(u => u.UserName == "2"))
        {
            var basicCustomer = new IdentityUser { UserName = "2" };

            userManager.CreateAsync(basicCustomer, "2").GetAwaiter().GetResult();
            userManager.AddClaimAsync(basicCustomer, new Claim(Constants.ClaimTypeName, Constants.Customer)).GetAwaiter()
                .GetResult();
        }

        return app;
    }
}