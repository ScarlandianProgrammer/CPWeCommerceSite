using Microsoft.AspNetCore.Mvc;

namespace CPWeCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
