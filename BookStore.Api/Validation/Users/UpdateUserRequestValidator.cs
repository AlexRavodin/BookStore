using BookStore.Api.Models.Auth.Request;
using BookStore.Api.Models.Users.Request;
using FluentValidation;

namespace BookStore.Api.Validation.Users;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(u => u.NewName).NotEmpty().Length(1, 20);
    }
}