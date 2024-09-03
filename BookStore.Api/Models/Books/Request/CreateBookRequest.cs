namespace BookStore.Api.Models.Books.Request;

public record CreateBookRequest(int Id, string Name, string Summary, decimal Price, string QualityDescription, int AuthorId);
