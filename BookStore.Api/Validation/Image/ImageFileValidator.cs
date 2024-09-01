using FluentValidation;

namespace BookStore.Api.Validation.Image;

public class ImageFileValidator : AbstractValidator<IFormFile>
{
    private static readonly string[] ValidExtensions = [".jpeg", ".png", ".jpg", ".webp"];
    
    private const string InvalidExtensionMessage = "Only '.jpeg', '.png', '.jpg', '.webp' extensions are avaialable";
    
    public ImageFileValidator()
    {
        RuleFor(f => f.FileName).NotEmpty();
        RuleFor(f => f.FileName).Must(BeValidFileExtension).WithMessage(InvalidExtensionMessage);
        RuleFor(f => f.Length).LessThan(500_000);    
    }

    private bool BeValidFileExtension(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        
        return ValidExtensions.Contains(extension);
    }
}