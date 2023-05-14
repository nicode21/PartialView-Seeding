using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_backend.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Product> products = await _context.Products.Include(m => m.Images).Take(4).Where(m => !m.SoftDelete).ToListAsync();
            var count = await _context.Products.Where(m => !m.SoftDelete).CountAsync();
            ViewBag.count = count;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete).Skip(skip).Take(4).ToListAsync();
            return PartialView("_ProductsPartial",products);
        }
    }
}
