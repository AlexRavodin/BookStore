using BookStore.Api.Data;
using BookStore.Api.Models.Authors.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repositories.Authors;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> Get()
    {
        return await _context.Authors.ToListAsync();
    }
}