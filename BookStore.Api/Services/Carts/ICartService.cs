using BookStore.Api.Models.Carts;
using BookStore.Api.Models.Carts.Entity;
using BookStore.Api.Models.Carts.Request;
using BookStore.Api.Models.Carts.Response;

namespace BookStore.Api.Services.Carts;

public interface ICartService
{
    public Task<CartDetails> GetCart(Guid userId);

    public Task<int> AddToCart(AddToCartRequest addToCartRequest);
    
    public Task<CartDetails> UpdateCart(UpdateCartItemCountRequest updateCartItemCountRequest);
}