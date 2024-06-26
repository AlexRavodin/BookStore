namespace BookStore.Api.Models.Users.Request;

public record UpdatePasswordRequest(Guid UserId, string NewPassword);