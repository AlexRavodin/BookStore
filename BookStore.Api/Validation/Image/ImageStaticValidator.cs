using BookStore.Api.Helpers;

namespace BookStore.Api.Validation.Image;

public static class ImageStaticValidator
{
    private static readonly string[] PermittedExtensions = [".jpeg", ".png", ".png", ".jpg", ".webp"];
    
    private static readonly string[] PermittedTypes = [Constants.BookImageType, Constants.UserImageType];

    private const long MaxFileSize = 10_000_000;
    
    public static bool ValidateFile(this IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (string.IsNullOrEmpty(extension) || !PermittedExtensions.Contains(extension))
        {
            return false;
        }

        if (file.Length > MaxFileSize)
        {
            return false;
        }

        return true;
    }
    
    public static bool ValidateImageType(this string type)
    {
        return !string.IsNullOrEmpty(type) && PermittedTypes.Contains(type);
    }
}