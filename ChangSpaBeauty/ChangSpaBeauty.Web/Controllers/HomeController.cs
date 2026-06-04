using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Application.Services;
using ChangSpaBeauty.Web.ViewModels;
using ChangSpaBeauty.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace ChangSpaBeauty.Web.Controllers;

public class HomeController : BaseController
{
    private readonly ProductService _productService;

    public HomeController(IShoppingCartService cartService,ProductService productService)
        : base(cartService)
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
