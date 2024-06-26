namespace BookStore.Api.Models.Auth.Request;

public record RegisterRequest(string Username, string Password, string ConfirmPassword);