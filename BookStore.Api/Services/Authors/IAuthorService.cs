using BookStore.Api.Models.Authors.Entity;

namespace BookStore.Api.Services.Authors;

public interface IAuthorService
{
    public Task<IEnumerable<AuthorItem>> GetAuthors();
}