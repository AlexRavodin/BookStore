namespace TestApp.Api.Models.Requests;

public record RegisterRequest(string Username, string Password, string ConfirmPassword);