using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Api.Models.Genres.Entity;
using BookStore.Api.Models.Images.Entity;

namespace BookStore.Api.Models.Books.Entity;

public class Book
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Summary { get; set; }
    
    public decimal Price { get; set; }
    
    public string QualityDescription { get; set; }
    
    public ICollection<Genre> Genres { get; set; }
    
    public ICollection<Author> Authors { get; set; }
    
    public Guid? BookImageId { get; set; }
    
    public BookImage? BookImage { get; set; }
}