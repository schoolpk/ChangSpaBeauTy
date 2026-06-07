using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Web.ViewModels.Category;
namespace ChangSpaBeauty.Web.ViewModels.Product;
public class ProductListViewModel
{
    public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
    public string? SelectedCategory { get; set; }
    public string? SelectedTrademark { get; set; }
    public string? SearchKeyword { get; set; }
    public string SortBy { get; set; } = "popular";


    public IEnumerable<CategorySidebar> Categories { get; set; } = new List<CategorySidebar>();
    public IEnumerable<string> Trademarks { get; set; } = new List<string>();
}
