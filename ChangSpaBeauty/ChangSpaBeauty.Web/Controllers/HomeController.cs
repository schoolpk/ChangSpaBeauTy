using ChangSpaBeauty.Application.Services;
using ChangSpaBeauty.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChangSpaBeauty.Web.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(string sort = "popular")
    {
        var products = sort switch
        {
            "newest"      => await _productService.GetAllProductsAsync(),
            "bestselling" => await _productService.GetPopularProductsAsync(),
            _ => await _productService.GetPopularProductsAsync(),
        };

        var vm = new ProductListViewModel
        {
            Products = products,
            SortBy   = sort
        };

        return View(vm);
    }

    public IActionResult Contact() => View();
}
