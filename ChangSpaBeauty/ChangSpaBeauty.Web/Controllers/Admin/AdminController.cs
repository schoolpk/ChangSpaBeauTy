
using ChangSpaBeauty.Application.DTOs;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Application.Services;
using ChangSpaBeauty.Domain.Interfaces;
using ChangSpaBeauty.Infrastructure.Repositories;
using ChangSpaBeauty.Web.ViewModels;
using ChangSpaBeauty.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ChangSpaBeauty.Web.Controllers;

 [Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly ProductService _productService;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IWebHostEnvironment _env;

    public AdminController(CategoryService categoryService, ProductService productService, IUserRepository userRepository, IWebHostEnvironment env, IOrderRepository orderRepository)
    {
        _categoryService = categoryService;
        _productService = productService;
        _userRepository = userRepository;
        _env = env;
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> Index()
    {
        // User
        var users = await _userRepository.GetAllAsync();
        var userList = users.ToList();
        ViewBag.Users = userList;
        ViewBag.TotalUsers = userList.Count;
        ViewBag.NewUsersThisMounth = 0;
        // Product
        var products = await _productService.GetAllProductsAsync();
        var productList = products.ToList();
        ViewBag.Products = productList;
        ViewBag.TotalProducts = productList.Count;
        // Category
        var categories = await _categoryService.GetAllAsync();
        var categoryList = categories.ToList();
        ViewBag.Categories = categories;
        ViewBag.TotalCategories = categoryList.Count;
        // Order
        var orders = await _orderRepository.GetAllAsync();
        var orderList = orders.ToList();
        ViewBag.Orders = orderList;
        ViewBag.TotalOrders = orderList.Count;
        ViewBag.TotalProductsSold = orderList
                            .SelectMany(o => o.OrderDetails)
                            .Sum(od => od.Quantity);

        return View();

    }

    // CATEGORY - LIST
    public async Task<IActionResult> Categories()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories);
    }

    // CATEGORY - CREATE
    [HttpGet]
    public IActionResult CreateCategory() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCategory(CategoryCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var (success, message) = await _categoryService.CreateAsync(model.Name, model.TradeMark);
        if (!success) 
        { 
            ModelState.AddModelError(nameof(model.Name), message);
            ModelState.AddModelError(nameof(model.TradeMark), message);
            return View(model); 
        }
        TempData["Success"] = message;
        return RedirectToAction(nameof(Index));
    }

    // CATEGORY - EDIT
    [HttpGet]
    public async Task<IActionResult> EditCategory(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null) return NotFound();
        var model = new CategoryCreateViewModel { Name = category.Name};
        ViewBag.CategoryId = id;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCategory(int id, CategoryCreateViewModel model)
    {
        if (!ModelState.IsValid) { ViewBag.CategoryId = id; return View(model); }
        var (success, message) = await _categoryService.UpdateAsync(id, model.Name);
        if (!success) { ModelState.AddModelError(nameof(model.Name), message); ViewBag.CategoryId = id; return View(model); }
        TempData["Success"] = message;
        return RedirectToAction(nameof(Index));
    }

    // CATEGORY - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var (success, message) = await _categoryService.DeleteAsync(id);
        if (success) TempData["Success"] = message;
        else TempData["Error"] = message;
        return RedirectToAction(nameof(Index));
    }

    // PRODUCT - LIST
    public async Task<IActionResult> Products()
    {
        var products = await _productService.GetAllProductsAsync();
        return View(products);
    }

    // PRODUCT - CREATE
    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        await LoadCategoriesAsync();
        return View(new ProductCreateViewModel());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProduct(ProductCreateViewModel model)
    {
        if (!ModelState.IsValid) { await LoadCategoriesAsync(); return View(model); }

        string? savedFileName = null;
        if (model.ImageFile != null && model.ImageFile.Length > 0)
        {
            var allowedExt = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
            var ext = Path.GetExtension(model.ImageFile.FileName).ToLowerInvariant();
            if (!allowedExt.Contains(ext)) { ModelState.AddModelError(nameof(model.ImageFile), "Chỉ chấp nhận JPG, PNG, WebP, GIF."); 
                await LoadCategoriesAsync(); 
                return View(model); }
            if (model.ImageFile.Length > 5 * 1024 * 1024) { ModelState.AddModelError(nameof(model.ImageFile), "Ảnh không được vượt quá 5MB."); 
                await LoadCategoriesAsync(); 
                return View(model); }
            savedFileName = $"{Guid.NewGuid()}{ext}";
            var folder = Path.Combine(_env.WebRootPath, "images", "products");
            Directory.CreateDirectory(folder);
            using var stream = new FileStream(Path.Combine(folder, savedFileName), FileMode.Create);
            await model.ImageFile.CopyToAsync(stream);
        }

        var productDto = new ProductDto
        {
            Name = model.Name,
            Price = model.Price,
            CategoryId = model.CategoryId,
            Image = savedFileName,
            Sold = 0,
            Stock = model.Stock,
            Description = model.Description
        };
        await _productService.AddProductAsync(productDto);
        TempData["Success"] = $"Đã thêm sản phẩm \"{model.Name}\" thành công!";
        return RedirectToAction(nameof(Index));
    }

    // PRODUCT - EDIT
    [HttpGet]
    public async Task<IActionResult> EditProduct(int id)
    {
        var products = await _productService.GetAllProductsAsync();
        var product = products.FirstOrDefault(p => p.ProductId == id);
        if(product == null)
        {
            return NotFound();
        }
        await LoadCategoriesAsync();
        var model = new ProductCreateViewModel
        {
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            Stock = product.Stock,
            Description = product.Description
        };
        ViewBag.ProductId = id;
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProduct(int id, ProductCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            ViewBag.ProductId = id;
            return View(model);
        }
        string? saveFileName = null;
        if(model.ImageFile != null && model.ImageFile.Length > 0)
        {
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
            var ext = Path.GetExtension(model.ImageFile.FileName).ToLowerInvariant();
            if (!allowed.Contains(ext))
            {
                ModelState.AddModelError(nameof(model.ImageFile), "Chỉ chấp nhận JPG, PNG, WebP, GIF.");
                await LoadCategoriesAsync(); 
                return View(model);
            }
            saveFileName = $"{Guid.NewGuid()}{ext}";
            var folder = Path.Combine(_env.WebRootPath, "images", "products");
            Directory.CreateDirectory(folder);
            using var stream = new FileStream(Path.Combine(folder, saveFileName), FileMode.Create);
            await model.ImageFile.CopyToAsync(stream);
        }
        var productDto = new ProductDto
        {
            ProductId = id,
            Name = model.Name,
            Price = model.Price,
            CategoryId = model.CategoryId,
            Image = saveFileName
        };
        await _productService.UpdateProductAsync(productDto);
        TempData["Success"] = $"Cap nhat thanh cong\"{model.Name}\"!";
        return RedirectToAction(nameof(Index));
    }
    // PRODUCT - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        await _productService.DeleteProductAsync(id);
        TempData["Success"] = "Xoa thanh cong";
        return RedirectToAction(nameof(Index));
    }


    // ORDER - UPDATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, string status)
    {
        var allowed = new[] { "pending", "confirmed", "shipping", "done", "cancelled" };
        if (!allowed.Contains(status))
        {
            TempData["Error"] = "Không hợp lệ";
        }
        await _orderRepository.UpdateOrderAsync(orderId, status);
        TempData["Sucess"] = "Đã cập nhật";
        return RedirectToAction(nameof(Index));
    }
    private async Task LoadCategoriesAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = categories.Select(c => new SelectListItem
        {
            Value = c.CategoryId.ToString(),
            Text = c.Name
        }).ToList();
    }
}