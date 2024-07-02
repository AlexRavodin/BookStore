namespace BookStore.Api.Models.Users.Request;

public record UpdateUserRequest(Guid UserId, string NewName);