using Fiorello_backend.Data;
using Fiorello_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiorello_backend.ViewModels;

namespace Fiorello_backend.Controllers
{
    public class ContactController : Controller
    {

        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Expert> experts = await _context.Experts.Where(m => !m.SoftDelete).ToListAsync();

            ContactVM contact = new()
            {
                Experts = experts
            };

            return View(contact);
        }
    }
}
