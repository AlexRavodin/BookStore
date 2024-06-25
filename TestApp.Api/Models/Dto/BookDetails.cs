namespace TestApp.Api.Models.Dto;

public record BookDetails(int Id, string Name, string Summary,
    decimal Price, IEnumerable<string> Authors,
    string GenreName, string QualityDescription);