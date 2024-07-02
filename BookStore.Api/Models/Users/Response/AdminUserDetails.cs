namespace BookStore.Api.Models.Users.Response;

public record AdminUserDetails(Guid UserId, string Username, string Role, string ImagePath);