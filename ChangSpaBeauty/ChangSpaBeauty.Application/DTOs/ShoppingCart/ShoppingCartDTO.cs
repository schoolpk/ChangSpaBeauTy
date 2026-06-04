// ChangSpaBeauty.Application/DTOs/ShoppingCart/ShoppingCartDTO.cs
namespace ChangSpaBeauty.Application.DTOs.ShoppingCart;

public class ShoppingCartDTO
{
    public int ShoppingCartId { get; set; }
    public List<ShoppingCartItemDTO> Items { get; set; } = new(); 
    // ✅ List item, không phải list cart
    public decimal GrandTotal => Items.Sum(i => i.Total);
    public int TotalItems => Items.Sum(i => i.Quantity);
}