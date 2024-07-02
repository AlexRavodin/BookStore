using BookStore.Api.Models.Books.Request;
using FluentValidation;

namespace BookStore.Api.Validation.Books;

public class CreateBookRequestValidator : AbstractValidator<UpdateBookRequest> 
{
    public CreateBookRequestValidator()
    {
        RuleFor(b => b.Name).NotEmpty().Length(1, 100);
        RuleFor(b => b.Price).NotEmpty().InclusiveBetween(1, 1_000);
        RuleFor(b => b.Summary).Length(0, 1_000);
        RuleFor(b => b.QualityDescription).Length(0, 100);
    }
}