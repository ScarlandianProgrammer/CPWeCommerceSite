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

                return RedirectToAction("Index", "Home");
			}
            return View(newMember);
        }
    }
}
