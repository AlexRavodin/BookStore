namespace BookStore.Api.Models.Books.Entity;

public class Genre
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<Books.Entity.Book> Books { get; set; }
}