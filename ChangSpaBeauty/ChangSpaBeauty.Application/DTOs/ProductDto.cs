namespace ChangSpaBeauty.Application.DTOs;
public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategorySlug { get; set; } = "";
    public int Sold { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }

}
