using System.Data;
using BookStore.Api.Data;
using BookStore.Api.Models.Carts.Entity;
using BookStore.Api.Models.Carts.Request;
using BookStore.Api.Models.Carts.Response;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Services.Carts;

public class CartService : ICartService
{
    private readonly AppDbContext _context;

    public CartService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CartDetails> GetCart(Guid userId)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart is null)
        {
            cart = new Cart { UserId = userId };

            _context.Carts.Add(cart);

            await _context.SaveChangesAsync();

            return new CartDetails(cart.Id, userId, []);
        }

        var cartItems = await _context.CartItems.Where(ci => ci.CartId == cart.Id).Include(ci => ci.Book).Select(ci =>
            new CartItemDto(
                ci.BookId, ci.Book.Name, ci.Book.Price, ci.Count)).ToListAsync();

        return new CartDetails(cart.Id, userId, cartItems);
    }

    public async Task<int> AddToCart(AddToCartRequest addToCartRequest)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == addToCartRequest.UserId);

        if (cart is null)
        {
            cart = new Cart { UserId = addToCartRequest.UserId };

            _context.Carts.Add(cart);

            await _context.SaveChangesAsync();
        }

        var alreadyAdded =
            await _context.CartItems.AnyAsync(ci => ci.CartId == cart.Id && ci.BookId == addToCartRequest.BookId);

        if (alreadyAdded)
        {
            return cart.Id;
        }

        _context.CartItems.Add(new CartItem
        {
            Count = 1,
            BookId = addToCartRequest.BookId,
            CartId = cart.Id,
        });

        await _context.SaveChangesAsync();

        return cart.Id;
    }

    public Task<Cart> UpdateCart(UpdateCartItemCountRequest updateCartItemCountRequest)
    {
        throw new NotImplementedException();
    }
}