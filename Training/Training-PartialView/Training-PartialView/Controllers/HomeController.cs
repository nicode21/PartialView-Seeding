using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Fiorello_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Fiorello_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<Slider> sliders = await _context.Siders.Where(m=>!m.SoftDelete).ToListAsync();

            SliderInfo sliderInfo = await _context.SliderInfos.Where(m => !m.SoftDelete).FirstOrDefaultAsync();

            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDelete).OrderByDescending(m=>m.Id).Take(3).ToListAsync();

            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Product> products = await _context.Products.Include(m=>m.Images).Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Expert> experts = await _context.Experts.Where(m => !m.SoftDelete).ToListAsync();

            HomeVM home = new()
            {
                Sliders = sliders,
                SliderInfo = sliderInfo,
                Blogs = blogs,
                Categories = categories,
                Products = products,
                Experts = experts

            };


            return View(home);
        }
    }
}