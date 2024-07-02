namespace BookStore.Api.Services.Images;

public interface IImageService
{
    public Task<string> AddImageToUser(IFormFile image, Guid userId);

    public Task RemoveImageFromUser(Guid userId);
    
    public Task<string> AddImageToBook(IFormFile image, int bookId);

    public Task RemoveImageFromBook(int bookId);

    public Task<string> GetUserImagePath(Guid userId);
}