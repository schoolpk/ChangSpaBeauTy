using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Application.Services;
using ChangSpaBeauty.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly INotificationRepository _notiRepo;
        private readonly ProductService _productService;
        public BaseController(IShoppingCartService cartService, INotificationRepository notiRepo)
        {
            _cartService = cartService;
            _notiRepo = notiRepo;
        }
        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var cart = await _cartService.GetCartAsync(userId);
                ViewBag.CartCount = cart?.Items?.Sum(i=>i.Quantity) ?? 0;

                var notifRepo = HttpContext.RequestServices.GetRequiredService<INotificationRepository>();
                ViewBag.Notifications = await notifRepo.GetByUserAsync(userId);
                ViewBag.UnreadCount = await notifRepo.GetUnreadCountAsync(userId);
            }
            var unitOfWork = HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var categories = await unitOfWork.Categories.GetAllAsync();
            ViewBag.NavCategories = categories;
            await next();
        }
    }
}