using System.Data;
using BookStore.Api.Data;
using BookStore.Api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repositories.Books;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> Get(BookParameters parameters)
    {
        var books = ApplyAllParameters(_context.Books, parameters);
        
        return await books.Include(b => b.Genres)
            .Include(b => b.BookImage)
            .Skip((parameters.PageIndex - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
    }

    public async Task<int> GetCount(BookParameters parameters)
    {
        var books = ApplyAllParameters(_context.Books, parameters);

        return await books.CountAsync();
    }
    
    public async Task<Book> GetById(int id)
    {
        //TODO: check performance        
        
        var book = await _context.Books
            .Include(b => b.BookImage)
            .Include(b => b.Genres)
            .Include(b => b.Authors).
            FirstOrDefaultAsync(b => b.Id == id);

        if (book is null)
        {
            throw new DataException();
        }

        return book;
    }

    public async Task<Book> Add(Book book, int authorId)
    {
        var author = await _context.Authors.Where(a => a.Id == authorId).FirstOrDefaultAsync();

        if (author != null)
        {
            book.Authors.Add(author);
        }
        else
        {
            throw new Exception("Author not exists.");
        }

        var result = _context.Books.Add(book);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DataException();
        }
        
        return result.Entity;
    }

    public async Task<Book> Update(Book book)
    {
        _context.Books.Update(book);
        

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DataException();
        }
        
        return book;
    }

    public async Task<Book> UpdateGenres(int bookId, List<int> genreIds)
    {
        var book = await _context.Books
            .Include(b => b.Genres)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book == null)
        {
            throw new InvalidOperationException("Book not found");
        }
        
        book.Genres.Clear();
        
        var newGenres = await _context.Genres
            .Where(g => genreIds.Contains(g.Id))
            .ToListAsync();

        book.Genres = newGenres;

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task Delete(int id)
    {
        var bookToDelete = new Book { Id = id };
        
        _context.Books.Remove(bookToDelete);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DataException(e.Message);
        }
    }
    
    private IQueryable<Book> ApplyAllParameters(IQueryable<Book> books, BookParameters parameters)
    {
        // filtering
        books = books.Where(b => b.Price > parameters.MinimalPrice 
                                 && b.Price < parameters.MaximumPrice);

        // searching
        if (!string.IsNullOrEmpty(parameters.Name))
        {
            books = books.Where(b => b.Name.ToLower().Contains(parameters.Name.ToLower()));
        }
        
        // sorting
        if (parameters.OrderByPriceAscending)
        {
            books = books.OrderBy(b => b.Price);
        }
        if (parameters.OrderByPriceDescending)
        {
            books = books.OrderByDescending(b => b.Price);
        }

        return books;
    }
}