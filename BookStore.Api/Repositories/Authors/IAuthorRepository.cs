using BookStore.Api.Models.Authors.Entity;
using BookStore.Api.Models.Books.Entity;

namespace BookStore.Api.Repositories.Authors;

public interface IAuthorRepository
{
    public Task<IEnumerable<Author>> Get();
}