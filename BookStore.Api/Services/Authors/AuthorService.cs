using BookStore.Api.Models.Authors.Entity;
using BookStore.Api.Repositories.Authors;

namespace BookStore.Api.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<AuthorItem>> GetAuthors()
    {
        var authors = await _authorRepository.Get();
        
        return authors.Select(a => new AuthorItem(a.Id, $"{a.FirstName} {a.LastName}"));
    }
}