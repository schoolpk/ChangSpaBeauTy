using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Application.Services;
using ChangSpaBeauty.Domain.Interfaces;
using ChangSpaBeauty.Web.ViewModels;
using ChangSpaBeauty.Web.ViewModels.Category;
using ChangSpaBeauty.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace ChangSpaBeauty.Web.Controllers;

public class ProductsController : BaseController
{
    private readonly ProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(ProductService productService, IShoppingCartService cartService,
        IUnitOfWork unitOfWork, INotificationRepository notiRepo)
        : base(cartService, notiRepo)
    {
        _productService = productService;
        _unitOfWork = unitOfWork;
    }

    public static readonly Dictionary<string, string> _categoryMap = new()
    {
        { "duong-da",         "Dưỡng da mặt" },
        { "trang-diem",       "Trang điểm" },
        { "cham-soc-co-the",  "Chăm sóc cơ thể" },
        { "nuoc-hoa",         "Nước hoa" },
        { "combo",            "Combo tiết kiệm" },
    };
    public async Task<IActionResult> Index(int? category, string? keyword, string? trademark, string sort = "popular")
    {
        var allCategories = await _unitOfWork.Categories.GetAllAsync();
        var products = await _productService.GetAllProductsAsync();

        // Filter theo CategoryId khi click sidebar/nav
        if (category.HasValue)
            products = products.Where(p => p.CategoryId == category.Value);

        // Search keyword — tìm theo tên sản phẩm, tên category, trademark
        if (!string.IsNullOrEmpty(keyword))
        {
            products = products.Where(p =>
                p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || (p.CategoryName != null && p.CategoryName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                || (p.Trademark != null && p.Trademark.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
        }

        if (!string.IsNullOrEmpty(trademark))
            products = products.Where(p => p.Trademark == trademark);

        products = sort switch
        {
            "newest" => products.OrderByDescending(p => p.ProductId),
            "bestselling" => products.OrderByDescending(p => p.Sold),
            "price-asc" => products.OrderBy(p => p.Price),
            "price-desc" => products.OrderByDescending(p => p.Price),
            _ => products.OrderByDescending(p => p.Sold),
        };

        // Sidebar — luôn hiện tất cả categories
        var categorySidebar = allCategories.Select(c => new CategorySidebar
        {
            CategoryId = c.CategoryId,
            Name = c.Name,
            Total = c.Products?.Count() ?? 0,
            Slug = c.CategoryId.ToString()
        }).ToList();

        var trademarks = allCategories
            .Where(c => !string.IsNullOrEmpty(c.Trademark))
            .SelectMany(c => c.Trademark!.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Select(t => t.Trim())
            .Distinct()
            .ToList();

        ViewData["Keyword"] = keyword;

        var vm = new ProductListViewModel
        {
            Products = products,
            SortBy = sort,
            SelectedCategory = category?.ToString(),
            SearchKeyword = keyword,
            Categories = categorySidebar,
            Trademarks = trademarks
        };

        return View(vm);
    }

    public async Task<IActionResult> Details(int id)
    {
        var products = await _productService.GetAllProductsAsync();
        var product = products.FirstOrDefault(p => p.ProductId == id);
        if (product == null) return NotFound();
        return View(product);
    }

    public IActionResult Sale() => View();
}