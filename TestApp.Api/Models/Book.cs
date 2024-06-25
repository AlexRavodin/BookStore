namespace TestApp.Api.Models;

public class Book
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Summary { get; set; }
    
    public decimal Price { get; set; }
    
    public string QualityDescription { get; set; }
    
    public int GenreId { get; set; }
    
    public Genre Genre { get; set; }
    
    public ICollection<Author> Authors { get; set; }
}