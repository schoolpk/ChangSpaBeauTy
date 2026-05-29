namespace ChangSpaBeauty.Application.DTOs;
public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public int Sold { get; set; }

}
