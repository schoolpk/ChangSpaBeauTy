using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IShoppingCartService _cartService;
        public BaseController(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }
        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var cart = await _cartService.GetCartAsync(userId);
                ViewBag.CartCount = cart?.Items?.Sum(i=>i.Quantity) ?? 0;

                var notificationService = HttpContext.RequestServices.GetRequiredService<NotificationService>();
                var notifications = notificationService.GetNotifications(HttpContext.Session, userId);
                ViewBag.Notifications = notifications;
                ViewBag.UnreadCount = notifications.Count;
            }
            await next();
        }
    }
}