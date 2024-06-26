namespace BookStore.Api.Models.Books.Response;

public record BookDetails(int Id, string Name, string Summary,
    decimal Price, IEnumerable<string> Authors,
    string GenreName, string QualityDescription);