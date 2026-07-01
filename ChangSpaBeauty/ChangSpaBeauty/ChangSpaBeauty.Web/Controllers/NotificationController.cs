using ChangSpaBeauty.Application.Interfaces;
using ChangSpaBeauty.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChangSpaBeauty.Web.Controllers
{
    [Authorize]
    public class NotificationController : BaseController
    {
      
        private readonly INotificationRepository _notiRepo;

        public NotificationController(
            IShoppingCartService cartService,
            INotificationRepository notiRepo) : base(cartService, notiRepo)
        {
            _notiRepo = notiRepo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearAll()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _notiRepo.DeleteAllAsync(userId);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkRead()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _notiRepo.MarkAllReadAsync(userId);
            return Ok();
        }
    }
}