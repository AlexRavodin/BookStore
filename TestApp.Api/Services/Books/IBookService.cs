using TestApp.Api.Helpers;
using TestApp.Api.Models.Dto;

namespace BookStoreTest.Api.Services.Books;

public interface IBookService
{
    public Task<PagedList<BookListItem>> GetBooks(BookParameters parameters);
    
    public Task<BookDetails> GetBookById(int id);
}