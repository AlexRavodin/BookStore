using BookStore.Api.Models.Auth.Request;
using FluentValidation;

namespace BookStore.Api.Validation.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(u => u.Username).NotEmpty().Length(1, 20);
        RuleFor(u => u.Password).NotEmpty().Length(1, 20);
        RuleFor(u => u.ConfirmPassword).Equal(u => u.Password).WithMessage("Confirm password must be equal to password.").Length(1, 20);
    }
}