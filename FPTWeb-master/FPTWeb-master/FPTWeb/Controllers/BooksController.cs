using FPTWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace FPTWeb.Controllers
{
	public class BooksController : Controller
	{
		private readonly ApplicationDbContext _context;

		public BooksController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Books
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher).Include(b => b.StoreOwner);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Books/Details/5
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

		// GET: Books/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
			ViewData["StoreOwnerId"] = new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId");
			return View();
		}

		// POST: Books/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("BookId,BookImage,Title,Description,Price,AuthorId,CategoryId,PublisherId,StoreOwnerId")] Book book)
		{
			if (ModelState.IsValid)
			{
				_context.Add(book);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", book.AuthorId);
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", book.CategoryId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", book.PublisherId);
			ViewData["StoreOwnerId"] = new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", book.StoreOwnerId);
			return View(book);
		}

		// GET: Books/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Books == null)
			{
				return NotFound();
			}

			var book = await _context.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}
			ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName", book.PublisherId);
			ViewData["StoreOwnerId"] = new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", book.StoreOwnerId);
			return View(book);
		}

		// POST: Books/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("BookId,BookImage,Title,Description,Price,AuthorId,CategoryId,PublisherId,StoreOwnerId")] Book book)
		{
			if (id != book.BookId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(book);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BookExists(book.BookId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", book.AuthorId);
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", book.CategoryId);
			ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", book.PublisherId);
			ViewData["StoreOwnerId"] = new SelectList(_context.StoreOwners, "StoreOwnerId", "StoreOwnerId", book.StoreOwnerId);
			return View(book);
		}

		// GET: Books/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
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

		// POST: Books/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Books == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
			}
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		[Authorize(Roles = "Admin")]
		private bool BookExists(int id)
		{
			return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
		}
	}
}
