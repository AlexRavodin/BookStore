namespace BookStore.Api.Models.Carts.Response;

public record CartItem(int BookId, string BookName, decimal Price, int Count);