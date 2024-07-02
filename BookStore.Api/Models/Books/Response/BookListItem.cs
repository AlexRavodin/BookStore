using BookStore.Api.Models.Genres.Response;

namespace BookStore.Api.Models.Books.Response;

public record BookListItem(int Id, string Name, decimal Price, IEnumerable<GenreListItem> Genres, string ImagePath);