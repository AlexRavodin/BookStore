using BookStore.Api.Helpers;
using BookStore.Api.Models.Users.Request;
using FluentValidation;

namespace BookStore.Api.Validation.Users;

public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
{
    public UpdateRoleRequestValidator()
    {
        RuleFor(u => u.NewRoleName).Must(r => r is Constants.Admin
            or Constants.Moderator or Constants.Customer);
    }
}