using CPWeCommerceSite.Data;
using CPWeCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index(int? id)
        {
            const int NumProductsPerPage = 3;

            // set currentPage to id if it's not null, otherwise set it to 1
            int currentPage = id ?? 1;
            const int PageOffset = 1;

            // get total number of products
            int totalProducts = await _context.Products.CountAsync();
            // rounding pages up to nearest whole number
            double MaxNumPages = Math.Ceiling((double)totalProducts / NumProductsPerPage);
            int lastPage = Convert.ToInt32(MaxNumPages);

            // get products from DB
            List<Product> products = await (from product in _context.Products
                                            select product)
                                            .Skip(NumProductsPerPage * (currentPage - PageOffset))
                                            .Take(NumProductsPerPage)
                                            .ToListAsync();

            ProductCatalogViewModel catalogModel = 
                new ProductCatalogViewModel(products, lastPage, currentPage);

            // put them on the page
            return View(catalogModel);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(productModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = productModel.Title + " was updated Successfully.";

                return RedirectToAction("Index");
            }
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{product.Title} was deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["Message"] = $"This game was already deleted";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
