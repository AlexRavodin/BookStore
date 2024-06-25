using TestApp.Api.Helpers;
using TestApp.Api.Models;

namespace TestApp.Api.Repositories.Books;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> Get(BookParameters parameters);

    public Task<int> GetCount(BookParameters parameters);

    public Task<Book> GetById(int id);

    public Task<int> Add(Book book);
    
    public Task<bool> Update(Book book);

    public Task<bool> Delete(int id);
}