using Microsoft.AspNetCore.Mvc;

namespace ProductEndpoint.Controllers
{
    public sealed class ProductsPageController : Controller
    {
        [HttpGet]
        public IActionResult Index(int siteId = 35619)
        {
            ViewData["SiteId"] = siteId;
            return View();
        }
    }
}
