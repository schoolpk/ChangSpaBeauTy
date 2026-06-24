using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers;

[Authorize]
public class CartController : BaseController
{
    private readonly IShoppingCartService _cartService;

    public CartController(IShoppingCartService cartService, INotificationRepository notiRepo):base(cartService,notiRepo)
    {
        _cartService = cartService;
    }

    private int GetUserId()
    {
        var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(value))
            throw new UnauthorizedAccessException("User not authenticated");
        return int.Parse(value);
    }


    // ==================== XEM GIỎ HÀNG ====================
    public async Task<IActionResult> Index()
    {
        var cart = await _cartService.GetCartAsync(GetUserId());
        return View(cart);
    }

    // ==================== THÊM VÀO GIỎ ====================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        try
        {
            await _cartService.AddToCartAsync(GetUserId(), productId, quantity);
            TempData["SuccessMessage"] = "Đã thêm sản phẩm vào giỏ hàng!";
        }
        catch (InvalidOperationException ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
        return RedirectToAction("Index","Products");
        
    }

    // ==================== CẬP NHẬT SỐ LƯỢNG ====================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
    {
        await _cartService.UpdateQuantityAsync(GetUserId(), cartItemId, quantity);
        return RedirectToAction("Index");
    }

    // ==================== XÓA SẢN PHẨM ====================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCartItem(int cartItemId)
    {
        await _cartService.DeleteAsync(GetUserId(), cartItemId);
        TempData["SuccessMessage"] = "Đã xóa sản phẩm khỏi giỏ hàng.";
        return RedirectToAction("Index");
    }

    // ==================== XÓA TOÀN BỘ GIỎ ====================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ClearCart()
    {
        await _cartService.ClearCartAsync(GetUserId());
        return RedirectToAction("Index");
    }

    // ==================== THÊM AJAX (trả JSON) ====================
    [HttpPost]
    public async Task<IActionResult> AddToCartAjax(int productId, int quantity = 1)
    {
        try
        {
            var userId = GetUserId();
            await _cartService.AddToCartAsync(userId, productId, quantity);
            var count = await _cartService.GetCartItemCountAsync(userId);
            return Json(new
            {
                success = true,
                cartCount = count
            });
        }catch(InvalidOperationException ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
    }
}
