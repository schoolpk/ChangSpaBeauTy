
using ChangSpaBeauty.Application.DTOs.Order;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _cartService;

        public OrderController(IOrderService orderService, IShoppingCartService cartService, INotificationRepository notiRepo)
            : base(cartService, notiRepo)
        {
            _orderService = orderService;
            _cartService = cartService;
        }


        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);


        public async Task<IActionResult> Checkout()
        {
            var cart = await _cartService.GetCartAsync(GetUserId());

            if (!cart.Items.Any())
                return RedirectToAction("Index", "Cart");

            var dto = new CheckoutDto
            {
                Address = User.FindFirstValue(ClaimTypes.StreetAddress) ?? "",
                Phone = ""
            };

            ViewBag.Cart = cart;
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(OrderDto dto)
        {
            try
            {
                var orderId = await _orderService.PlaceOrderAsync(GetUserId(), dto);
                return RedirectToAction("Success", new { id = orderId });
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Checkout");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var (success, message) = await _orderService.CancelOrderAsync(orderId, GetUserId());

            if (success) TempData["Success"] = message;
            else TempData["Error"] = message;
            return RedirectToAction("MyOrders");
        }

        // ← thêm param status để filter
        public async Task<IActionResult> MyOrders(string? status)
        {
            var orders = await _orderService.GetUserOrderAsync(GetUserId());

            if (!string.IsNullOrEmpty(status))
                orders = orders.Where(o => o.Status == status).ToList();

            ViewBag.SelectedStatus = status ?? "all";
            return View(orders);
        }

        public async Task<IActionResult> Success(int id)
        {
            var order = await _orderService.GetOrderAsync(id, GetUserId());
            if (order == null) return NotFound();
            return View(order);
        }
    }
}
