using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Api.Helpers;

namespace BookStore.Api.Models.Images.Entity;

public class UserImage
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string Extension { get; set; } = string.Empty;

    [NotMapped] public string RelativePath => Path.Combine(Constants.UserImageBasePath, Id + Extension);
}