using BookStore.Api.Models.Genres.Response;

namespace BookStore.Api.Models.Books.Response;

public record BookDetails(int Id, string Name, string Summary,
    decimal Price, IEnumerable<string> Authors,
    IEnumerable<GenreListItem> Genres, string QualityDescription, string ImagePath);