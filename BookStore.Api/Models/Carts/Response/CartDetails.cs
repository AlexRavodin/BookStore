namespace BookStore.Api.Models.Carts.Response;

public record CartDetails(int CartId, Guid UserId, IEnumerable<CartItem> CartItems);