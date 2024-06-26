namespace BookStore.Api.Models.Carts.Response;

public record CartItemDto(int BookId, string BookName, decimal Price, int Count);