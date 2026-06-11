using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Web.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers
{
    [Authorize]
    public class NotificationController : BaseController
    {
        private readonly NotificationService _notificationService;
        public NotificationController(IShoppingCartService cartService,NotificationService notificationService) : base(cartService)
        {
            _notificationService = notificationService;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearAll()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _notificationService.MarkAllRead(HttpContext.Session, userId);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
