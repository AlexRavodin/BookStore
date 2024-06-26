using BookStore.Api.Helpers;
using BookStore.Api.Models.Books.Request;
using BookStore.Api.Models.Books.Response;
using BookStore.Api.Repositories.Books;

namespace BookStore.Api.Services.Books;

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

    public async Task<BookDetails> UpdateBook(UpdateBookRequest updateBookRequest)
    {
        var book = await _bookRepository.GetById(updateBookRequest.Id);

        if (!string.IsNullOrEmpty(updateBookRequest.Summary))
        {
            book.Summary = updateBookRequest.Summary;
        }
        
        if (!string.IsNullOrEmpty(updateBookRequest.Name))
        {
            book.Name = updateBookRequest.Name;
        }
        
        if (!string.IsNullOrEmpty(updateBookRequest.QualityDescription))
        {
            book.QualityDescription = updateBookRequest.QualityDescription;
        }
        
        book.Price = updateBookRequest.Price;

        await _bookRepository.Update(book);

        return new BookDetails(book.Id, book.Name, book.Summary, book.Price,
            book.Authors.Select(a => $"{a.FirstName} {a.LastName}"), book.Genre.Name, book.QualityDescription);
    }

    public async Task DeleteBook(int id)
    {
        await _bookRepository.Delete(id);
    }
}