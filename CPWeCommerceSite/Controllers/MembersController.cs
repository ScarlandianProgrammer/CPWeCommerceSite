using CPWeCommerceSite.Data;
using CPWeCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPWeCommerceSite.Controllers
{
    public class MembersController : Controller
    {
		private readonly ProductContext _context;

		public MembersController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newMember)
        {
            if (ModelState.IsValid)
            {
                // map RegisterViewModel to Member
                Member member = new()
                {
                    Email = newMember.Email,
                    Password = newMember.Password
                };
				_context.Members.Add(member);
				await _context.SaveChangesAsync();

                LogUserIn(member.Email);

                return RedirectToAction("Index", "Home");
			}
            return View(newMember);
        }

        [HttpGet]
        public IActionResult Login()
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel) 
        {
            if (ModelState.IsValid)
            {
                Member? m = (from member in _context.Members
                                where member.Email == loginModel.Email &&
                                      member.Password == loginModel.Password
                            select member).SingleOrDefault();
                if (m != null)
                {
                    LogUserIn(loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Credentials not found!");

            return View(loginModel);
        }

        private void LogUserIn(string email)
        {
            HttpContext.Session.SetString("Email", email);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
