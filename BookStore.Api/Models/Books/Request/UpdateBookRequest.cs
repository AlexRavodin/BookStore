namespace BookStore.Api.Models.Books.Request;

public record UpdateBookRequest(int Id, string Name, string Summary, decimal Price, string QualityDescription);
