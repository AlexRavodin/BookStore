using BookStore.Api.Data;
using BookStore.Api.Models.Images.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repositories.Images;

public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;

    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserImage> AddUserImage(UserImage userImage)
    {
        var result = _context.UserImages.Add(userImage);
        
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> RemoveUserImage(Guid id)
    {
        if (!_context.UserImages.Any(i => i.Id == id)) return false;

        var image = await _context.UserImages.FirstAsync(ui => ui.Id == id);

        _context.UserImages.Remove(image);              
            
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<BookImage> AddBookImage(BookImage bookImage)
    {
        var result = _context.BookImages.Add(bookImage);
        
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> RemoveBookImage(Guid id)
    {
        if (!_context.BookImages.Any(i => i.Id == id)) return false;
        
        var image = await _context.UserImages.FirstAsync(bi => bi.Id == id);

        _context.UserImages.Remove(image);                      
            
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserImage?> FindByUserId(Guid userId)
    {
        var image = await _context.UserImages.FirstOrDefaultAsync(i => i.UserId == userId);

        return image;
    }

    public async Task<BookImage?> FindByBookId(int bookId)
    {
        var image = await _context.BookImages.FirstOrDefaultAsync(i => i.BookId == bookId);

        return image;
    }
}