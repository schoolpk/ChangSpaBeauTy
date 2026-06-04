using ChangSpaBeauty.Application.Interfaces;
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
                ViewData["CartCount"] = await _cartService.GetCartItemCountAsync(userId);
            }
            else
            {
                ViewData["CartCount"] = 0;
            }

            await next();
        }
    }
}