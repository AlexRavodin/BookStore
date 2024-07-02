using BookStore.Api.Models.Auth.Request;
using FluentValidation;

namespace BookStore.Api.Validation.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(u => u.Username).NotEmpty().Length(1, 20);
        RuleFor(u => u.Password).NotEmpty().Length(1, 20);
    }
}