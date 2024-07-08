using BookStore.Api.Helpers;
using BookStore.Api.Models.Books.Request;
using BookStore.Api.Models.Books.Response;
using BookStore.Api.Models.Genres.Response;
using BookStore.Api.Repositories.Books;
using BookStore.Api.Repositories.Genres;
using BookStore.Api.Services.Images;

namespace BookStore.Api.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    private readonly IGenreRepository _genreRepository;

    public BookService(IBookRepository bookRepository, IImageService imageService, IGenreRepository genreRepository)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
    }

    public async Task<PagedList<BookListItem>> GetBooks(BookParameters parameters)
    {
        var books = await _bookRepository.Get(parameters);

        var count = await _bookRepository.GetCount(parameters);

        return new PagedList<BookListItem>(
            books.Select(b => new BookListItem(b.Id, b.Name, b.Price,
                b.Genres.Select(g => new GenreListItem(g.Id, g.Name, false)),
                b.BookImage?.RelativePath ?? Constants.DefaultBookImagePath)), count, parameters.PageSize);
    }

    public async Task<BookDetails> GetBookById(int id)
    {
        var book = await _bookRepository.GetById(id);

        var allGenres = await _genreRepository.Get();

        var genreList = allGenres.Select(g => new GenreListItem(
            g.Id, g.Name, book.Genres.Any(bg => bg.Id == g.Id)));

        return new BookDetails(book.Id, book.Name, book.Summary, book.Price,
            book.Authors.Select(a => $"{a.FirstName} {a.LastName}"), genreList, book.QualityDescription,
            book.BookImage?.RelativePath ?? Constants.DefaultBookImagePath);
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
        
        var allGenres = await _genreRepository.Get();
        var genreList = allGenres.Select(g => new GenreListItem(
            g.Id, g.Name, book.Genres.Any(bg => bg.Id == g.Id)));

        return new BookDetails(book.Id, book.Name, book.Summary, book.Price,
            book.Authors.Select(a => $"{a.FirstName} {a.LastName}"), genreList, book.QualityDescription,
            Constants.DefaultBookImagePath);
    }

    public async Task DeleteBook(int id)
    {
        await _bookRepository.Delete(id);
    }
}