using ChangSpaBeauty.Application.Services;
using ChangSpaBeauty.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChangSpaBeauty.Web.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(string? category, string? keyword, string sort = "popular")
    {
        var products = await _productService.GetAllProductsAsync();

        if (!string.IsNullOrEmpty(keyword))
            products = products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        products = sort switch
        {
            "newest"      => products.OrderByDescending(p => p.ProductId),
            "bestselling" => products.OrderByDescending(p => p.Sold),
            "price-asc"   => products.OrderBy(p => p.Price),
            "price-desc"  => products.OrderByDescending(p => p.Price),
            _             => products.OrderByDescending(p => p.Sold),
        };

        ViewData["Keyword"] = keyword;

        var vm = new ProductListViewModel
        {
            Products         = products,
            SortBy           = sort,
            SelectedCategory = category,
            SearchKeyword    = keyword
        };

        return View(vm);
    }

    public async Task<IActionResult> Details(int id)
    {
        var products = await _productService.GetAllProductsAsync();
        var product  = products.FirstOrDefault(p => p.ProductId == id);
        if (product == null) return NotFound();
        return View(product);
    }

    public IActionResult Sale() => View();
}
