using BookStore.Api.Exceptions;
using BookStore.Api.Helpers;
using BookStore.Api.Models.Images.Entity;
using BookStore.Api.Repositories.Images;

namespace BookStore.Api.Services.Images;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public ImageService(IImageRepository imageRepository, IWebHostEnvironment webHostEnvironment)
    {
        _imageRepository = imageRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> AddImageToUser(IFormFile image, Guid userId)
    {
        await RemoveImageFromUser(userId);
        
        var extension =  Path.GetExtension(image.FileName).ToLowerInvariant();

        var newImage = new UserImage
        {
            UserId = userId,
            Extension = extension
        };
        var addedImage = await _imageRepository.AddUserImage(newImage);
        
        DeleteFile(addedImage.RelativePath);
        await SaveFile(image, addedImage.RelativePath);
        
        return addedImage.RelativePath;
    }

    public async Task RemoveImageFromUser(Guid userId)
    {
        var image = await _imageRepository.FindByUserId(userId);

        if (image is null)
        {
            return;
        }
        
        DeleteFile(image.RelativePath);
        await _imageRepository.RemoveUserImage(image.Id);
    }

    public async Task<string> AddImageToBook(IFormFile image, int bookId)
    {
        await RemoveImageFromBook(bookId);
        
        var extension =  Path.GetExtension(image.FileName).ToLowerInvariant();

        var newImage = new BookImage
        {
            BookId = bookId,
            Extension = extension
        };
        var addedImage = await _imageRepository.AddBookImage(newImage);
        
        DeleteFile(addedImage.RelativePath);
        await SaveFile(image, addedImage.RelativePath);
        
        return addedImage.RelativePath;
    }

    public async Task RemoveImageFromBook(int bookId)
    {
        var image = await _imageRepository.FindByBookId(bookId);

        if (image is null)
        {
            return;
        }
        
        DeleteFile(image.RelativePath);
        await _imageRepository.RemoveUserImage(image.Id);
    }

    public async Task<string> GetUserImagePath(Guid userId)
    {
        var image = await _imageRepository.FindByUserId(userId);

        return image is null ? Constants.DefaultUserImagePath : image.RelativePath;
    }

    private void DeleteFile(string path)
    {
        var absolutePath = Path.Combine(_webHostEnvironment.WebRootPath, path);

        if (!File.Exists(absolutePath))
        {
            return;
        }
        
        try
        {
            File.Delete(absolutePath);
        }
        catch (Exception exception)
        {
            throw new FileDeleteException(exception.Message);
        }
    }
    
    private async Task SaveFile(IFormFile file, string path)
    {
        var absolutePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        
        try
        {
            await using var stream = File.Create(absolutePath);
            await file.CopyToAsync(stream);
        }
        catch (Exception exception)
        {
            throw new FileSaveException(exception.Message);
        }
    }
}