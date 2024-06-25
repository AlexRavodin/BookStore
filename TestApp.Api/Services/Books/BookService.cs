using TestApp.Api.Helpers;
using TestApp.Api.Models.Dto;
using TestApp.Api.Repositories.Books;

namespace BookStoreTest.Api.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<PagedList<BookListItem>> GetBooks(BookParameters parameters)
    {
        var books = await _bookRepository.Get(parameters);

        var count = await _bookRepository.GetCount(parameters);

        return new PagedList<BookListItem>(books.Select(x => new BookListItem(x.Id, x.Name, x.Price, x.Genre.Name)), count, parameters.PageSize);
    }

    public async Task<BookDetails> GetBookById(int id)
    {
        var book = await _bookRepository.GetById(id);
        
        return new BookDetails(book.Id, book.Name, book.Summary, book.Price,
            book.Authors.Select(a => $"{a.FirstName} {a.LastName}"), book.Genre.Name, book.QualityDescription);
    }
}