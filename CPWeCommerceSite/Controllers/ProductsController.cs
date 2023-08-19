using Microsoft.AspNetCore.Mvc;

namespace CPWeCommerceSite.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
