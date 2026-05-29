namespace ChangSpaBeauty.Domain.Entities;
public class ShoppingCart
{
    public int ShoppingCartId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}
