using BookStore.Api.Data;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Api.Extensions;

public static class IdentityExtension
{
    public static WebApplicationBuilder AddCustomIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    options.User.RequireUniqueEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return builder;
    }
}