using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Api.Helpers;

namespace BookStore.Api.Models.Images.Entity;

public class BookImage
{
    public Guid Id { get; set; }
    
    public int BookId { get; set; }
    
    public Book Book {get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string Extension { get; set; } = string.Empty;

    [NotMapped] public string RelativePath => Path.Combine(Constants.BookImageBasePath, Id + Extension);
}