using BookStore.Api.Helpers;

namespace BookStore.Api.Extensions;

public static class CorsExtension
{
    public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(Constants.CorsPolicy,
                policy =>
                {
                    policy.WithOrigins("http://localhost:5103/")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithExposedHeaders("X-Pagination");
                });
        });

        return builder;
    }
}