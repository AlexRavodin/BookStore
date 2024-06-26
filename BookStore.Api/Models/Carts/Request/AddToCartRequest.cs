namespace BookStore.Api.Models.Carts.Request;

public record AddToCartRequest(Guid UserId, int BookId);