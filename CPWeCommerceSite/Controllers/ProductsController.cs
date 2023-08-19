using CPWeCommerceSite.Data;
using CPWeCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPWeCommerceSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product) 
        {
            if (ModelState.IsValid)
            {
                // Add to DB
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // show success message on page
                ViewData["Message"] = $"{product.Title} was added successfully!";
                return View();
            }
            return View(product);
        }
    }
}
