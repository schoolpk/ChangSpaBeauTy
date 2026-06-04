namespace ChangSpaBeauty.Domain.Entities;
public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Total { get; set; }
    public string? Trademark { get; set; }
    public ICollection<Product>? Products { get; set; }
}
