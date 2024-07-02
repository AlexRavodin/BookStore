using BookStore.Api.Helpers;

namespace BookStore.Api.Extensions;

public static class AuthorizationExtension
{
    public static WebApplicationBuilder AddCustomPolices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Constants.Customer, pb =>
                pb.RequireClaim(Constants.ClaimTypeName, Constants.Customer, Constants.Moderator))
            .AddPolicy(Constants.Moderator, pb =>
                pb.RequireClaim(Constants.ClaimTypeName, Constants.Moderator))
            .AddPolicy(Constants.Admin, pb =>
                pb.RequireClaim(Constants.ClaimTypeName, Constants.Admin));

        return builder;
    }
}