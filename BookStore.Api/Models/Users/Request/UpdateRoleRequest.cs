namespace BookStore.Api.Models.Users.Request;

public record UpdateRoleRequest(Guid UserId, string NewRoleName);