using Microsoft.AspNetCore.Mvc;

namespace ChangSpaBeauty.Web.Controllers;

public class CartController : Controller
{
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Add(int productId)
    {
        // TODO: implement cart logic with session/cookie
        return RedirectToAction("Index", "Home");
    }
}
