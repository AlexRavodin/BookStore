using BookStore.Api.Helpers;

namespace BookStore.Api.Repositories.Books;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> Get(BookParameters parameters);

    public Task<int> GetCount(BookParameters parameters);

    public Task<Book> GetById(int id);

    public Task<Book> Add(Book book);
    
    public Task<Book> Update(Book book);

    public Task<Book> UpdateGenres(int bookId, List<int> genreIds);

    public Task Delete(int id);
}