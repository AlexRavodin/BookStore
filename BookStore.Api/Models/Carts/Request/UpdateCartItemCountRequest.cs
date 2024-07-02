namespace BookStore.Api.Models.Carts.Request;

public record UpdateCartItemCountRequest(Guid? UserId, int BookId, int NewCount);