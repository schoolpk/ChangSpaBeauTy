using ChangSpaBeauty.Application.DTOs.Order;
using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Entities;
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
        private readonly INotificationRepository _notiRepo; 
        private readonly IUserRepository _userRepository;   

        public OrderController(IOrderService orderService, IShoppingCartService cartService,
            INotificationRepository notiRepo, IUserRepository userRepository)
            : base(cartService, notiRepo)
        {
            _orderService = orderService;
            _cartService = cartService;
            _notiRepo = notiRepo;        
            _userRepository = userRepository;  
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

        [HttpGet]
        public async Task<IActionResult> EditOrder(int id)
        {
            var order = await _orderService.GetOrderAsync(id, GetUserId());
            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(UpdateOrderDto dto)
        {
            var (success, message) = await _orderService.UpdateOrderAsync(GetUserId(), dto);

            if (success)
            {
                TempData["Success"] = message;

                // Thông báo cho admin
                var admin = await _userRepository.GetAdminAsync();
                if (admin != null)
                {
                    await _notiRepo.AddAsync(new Notification
                    {
                        UserId = admin.Id,
                        Message = $"✏️ Khách hàng {User.Identity?.Name} đã chỉnh sửa đơn hàng #{dto.OrderId}",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });
                }

                return RedirectToAction("MyOrders");
            }

            TempData["Error"] = message;
            return RedirectToAction("EditOrder", new { id = dto.OrderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(OrderDto dto)
        {
            try
            {
                var orderId = await _orderService.PlaceOrderAsync(GetUserId(), dto);

                // ← Gửi thông báo cho admin khi có đơn hàng mới
                var admin = await _userRepository.GetAdminAsync();
                if (admin != null)
                {
                    await _notiRepo.AddAsync(new Notification
                    {
                        UserId = admin.Id,
                        Message = $"🛒 Khách hàng {User.Identity?.Name} vừa đặt đơn hàng #{orderId}",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });
                }

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

            if (success)
            {
                TempData["Success"] = message;

                // ← Gửi thông báo cho admin
                var admin = await _userRepository.GetAdminAsync();
                if (admin != null)
                {
                    await _notiRepo.AddAsync(new Notification
                    {
                        UserId = admin.Id,
                        Message = $"⚠️ Khách hàng {User.Identity?.Name} đã hủy đơn hàng #{orderId}",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });
                }
            }
            else
            {
                TempData["Error"] = message;
            }

            return RedirectToAction("MyOrders");
        }

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