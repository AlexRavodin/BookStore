namespace BookStore.Api.Models.Carts.Entity;

public class Cart
{
    public int Id { get; set; }
    
    public Guid UserId { get; set; }

    public ICollection<CartItem> CartItems { get; set; }
}