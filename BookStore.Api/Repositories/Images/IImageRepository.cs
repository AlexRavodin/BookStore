using BookStore.Api.Models.Images.Entity;

namespace BookStore.Api.Repositories.Images;

public interface IImageRepository
{
    public Task<UserImage> AddUserImage(UserImage userImage);
    
    public Task<BookImage> AddBookImage(BookImage bookImage);
    
    public Task<bool> RemoveUserImage(Guid id);
    
    public Task<bool> RemoveBookImage(Guid id);

    public Task<UserImage?> FindByUserId(Guid userId);
    
    public Task<BookImage?> FindByBookId(int bookId);
}