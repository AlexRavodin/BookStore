using BookStore.Api.Models.Auth.Request;
using BookStore.Api.Models.Users.Request;
using FluentValidation;

namespace BookStore.Api.Validation.Users;

public class UpdatePasswordRequestValidator : AbstractValidator<UpdatePasswordRequest>
{
    public UpdatePasswordRequestValidator()
    {
        RuleFor(u => u.NewPassword).NotEmpty().Length(1, 20);
    }
}