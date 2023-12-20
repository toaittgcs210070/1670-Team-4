using FPTWeb.Controllers;
using FPTWeb.Data;
using FPTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace FPTWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Books == null)
			{
				return NotFound();
			}

			var book = await _context.Books
				.Include(b => b.Author)
				.Include(b => b.Category)
				.Include(b => b.Publisher)
				.Include(b => b.StoreOwner)
				.FirstOrDefaultAsync(m => m.BookId == id);
			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}

		public IActionResult Index()
		{
			var book = _context.Books
				  .Take(5)
				  .ToList();
			return View(book);
		}
        public IActionResult Store()
        {
            var book = _context.Books
                  .ToList();
            return View(book);
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