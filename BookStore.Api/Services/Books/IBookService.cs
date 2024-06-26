using BookStore.Api.Helpers;
using BookStore.Api.Models.Books.Request;
using BookStore.Api.Models.Books.Response;

namespace BookStore.Api.Services.Books;

public interface IBookService
{
    public Task<PagedList<BookListItem>> GetBooks(BookParameters parameters);
    
    public Task<BookDetails> GetBookById(int id);

    public Task<BookDetails> UpdateBook(UpdateBookRequest updateBookRequest);
    
    public Task DeleteBook(int id);
}