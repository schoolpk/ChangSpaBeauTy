using ChangSpaBeauty.Application.DTOs;
namespace ChangSpaBeauty.Web.ViewModels.Product;
public class ProductListViewModel
{
    public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
    public string? SelectedCategory { get; set; }
    public string? SelectedTrademark { get; set; }
    public string? SearchKeyword { get; set; }
    public string SortBy { get; set; } = "popular";

}
