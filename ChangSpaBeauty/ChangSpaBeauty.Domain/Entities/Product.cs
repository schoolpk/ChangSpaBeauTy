namespace ChangSpaBeauty.Domain.Entities;
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int Sold { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Trademark { get; set; }
}
