using ChangSpaBeauty.Application.DTOs.Order;
using ChangSpaBeauty.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _cartService;
        public OrderController(IOrderService orderService, IShoppingCartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }
        private int GetUserId()=> int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<IActionResult> Checkout()
        {
            var cart = await _cartService.GetCartAsync(GetUserId());
            if(!cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

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
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Checkout");
            }
            var orderId = await _orderService.PlaceOrderAsync(GetUserId(), dto);
            return RedirectToAction("Success", new {id = orderId});
        }
        
        public async Task<IActionResult> Success(int id)
        {
            var order = await _orderService.GetOrderAsync(id, GetUserId());
            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
