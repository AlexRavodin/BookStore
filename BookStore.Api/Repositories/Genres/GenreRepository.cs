using BookStore.Api.Data;
using BookStore.Api.Models.Genres.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repositories.Genres;

public class GenreRepository : IGenreRepository
{
    private readonly AppDbContext _context;

    public GenreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Genre>> Get()
    {
        return await _context.Genres.ToListAsync();
    }
    
    public async Task<IEnumerable<Genre>> Get(int bookId)
    {
        return await _context.Genres.Where(g => g.Books.Any(b => b.Id == bookId)).ToListAsync();
    }
}