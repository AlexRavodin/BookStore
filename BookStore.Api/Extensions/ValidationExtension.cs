using BookStore.Api.Helpers;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BookStore.Api.Extensions;

public static class ValidationExtension
{
    public static WebApplicationBuilder AddValidation(this WebApplicationBuilder builder)
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        return builder;
    }
}