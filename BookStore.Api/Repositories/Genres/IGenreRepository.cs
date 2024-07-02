using BookStore.Api.Models.Genres.Entity;

namespace BookStore.Api.Repositories.Genres;

public interface IGenreRepository
{
    public Task<IEnumerable<Genre>> Get();
    
    public Task<IEnumerable<Genre>> Get(int bookId);
}