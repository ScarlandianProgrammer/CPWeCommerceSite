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

        /// <summary>
        /// This takes the user to the register view
        /// </summary>
        /// <returns>The Register view</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// This validates the user's input, 
        /// and if it's valid, inserts them into the DB
        /// </summary>
        /// <param name="newMember">
        /// The <see cref="RegisterViewModel"/> 
        /// that contains the user's input data
        /// </param>
        /// <returns>The Home/Index view</returns>
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

        /// <summary>
        /// This takes the user to the Login view
        /// </summary>
        /// <returns>The Login view</returns>
        [HttpGet]
        public IActionResult Login()
        { 
            return View(); 
        }

        /// <summary>
        /// This takes the user input, and if it's valid, 
        /// and there's a corresponding Member in the DB, 
        /// logs them in
        /// </summary>
        /// <param name="loginModel">
        /// The <see cref="LoginViewModel"/> containing
        /// the user's input data
        /// </param>
        /// <returns>The Home/Index view</returns>
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

        /// <summary>
        /// Sets the user's email in the session
        /// </summary>
        /// <param name="email">The email of the user</param>
        private void LogUserIn(string email)
        {
            HttpContext.Session.SetString("Email", email);
        }

        /// <summary>
        /// Logs the user out of the session, and 
        /// redirects them to the Home/Index view
        /// </summary>
        /// <returns>The Home/Index view</returns>
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
