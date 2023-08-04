using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialViewComponents.Data;
using PartialViewComponents.Models;
using System.Diagnostics;

namespace PartialViewComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> GetByCategoryId(int id)
        {
            return View(_context.Products.Where(x => x.Category.CategoryId == id).ToList()); 
                   }



        public async Task<IActionResult> Index()
        {
            return _context.Products != null ?
                        View(await _context.Products.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Products'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}