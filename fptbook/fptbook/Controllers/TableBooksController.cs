using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fptbook.Models;

namespace fptbook.Controllers
{
    public class TableBooksController : Controller
    {
        private readonly FptbookStoreTeam4Context _context;

        public TableBooksController(FptbookStoreTeam4Context context)
        {
            _context = context;
        }

        // GET: TableBooks
        public async Task<IActionResult> Index()
        {
            var fptbookStoreTeam4Context = _context.TableBooks.Include(t => t.Author).Include(t => t.Category).Include(t => t.Publisher).Include(t => t.StoreOwner);
            return View(await fptbookStoreTeam4Context.ToListAsync());
        }

        // GET: TableBooks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TableBooks == null)
            {
                return NotFound();
            }

            var tableBook = await _context.TableBooks
                .Include(t => t.Author)
                .Include(t => t.Category)
                .Include(t => t.Publisher)
                .Include(t => t.StoreOwner)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tableBook == null)
            {
                return NotFound();
            }

            return View(tableBook);
        }

        // GET: TableBooks/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.TableAuthors, "AuthorId", "AuthorId");
            ViewData["CategoryId"] = new SelectList(_context.TableCategories, "CategoryId", "CategoryId");
            ViewData["PublisherId"] = new SelectList(_context.TablePublishers, "PublisherId", "PublisherId");
            ViewData["StoreOwnerId"] = new SelectList(_context.TableStoreOwners, "StoreOwnerId", "StoreOwnerId");
            return View();
        }

        // POST: TableBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,CategoryId,AuthorId,StoreOwnerId,PublisherId,BookPrice,BookDetail,BookImage1,BookImage2,BookImage3")] TableBook tableBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.TableAuthors, "AuthorId", "AuthorId", tableBook.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.TableCategories, "CategoryId", "CategoryId", tableBook.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.TablePublishers, "PublisherId", "PublisherId", tableBook.PublisherId);
            ViewData["StoreOwnerId"] = new SelectList(_context.TableStoreOwners, "StoreOwnerId", "StoreOwnerId", tableBook.StoreOwnerId);
            return View(tableBook);
        }

        // GET: TableBooks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TableBooks == null)
            {
                return NotFound();
            }

            var tableBook = await _context.TableBooks.FindAsync(id);
            if (tableBook == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.TableAuthors, "AuthorId", "AuthorId", tableBook.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.TableCategories, "CategoryId", "CategoryId", tableBook.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.TablePublishers, "PublisherId", "PublisherId", tableBook.PublisherId);
            ViewData["StoreOwnerId"] = new SelectList(_context.TableStoreOwners, "StoreOwnerId", "StoreOwnerId", tableBook.StoreOwnerId);
            return View(tableBook);
        }

        // POST: TableBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookId,BookTitle,CategoryId,AuthorId,StoreOwnerId,PublisherId,BookPrice,BookDetail,BookImage1,BookImage2,BookImage3")] TableBook tableBook)
        {
            if (id != tableBook.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableBookExists(tableBook.BookId))
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
            ViewData["AuthorId"] = new SelectList(_context.TableAuthors, "AuthorId", "AuthorId", tableBook.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.TableCategories, "CategoryId", "CategoryId", tableBook.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.TablePublishers, "PublisherId", "PublisherId", tableBook.PublisherId);
            ViewData["StoreOwnerId"] = new SelectList(_context.TableStoreOwners, "StoreOwnerId", "StoreOwnerId", tableBook.StoreOwnerId);
            return View(tableBook);
        }

        // GET: TableBooks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TableBooks == null)
            {
                return NotFound();
            }

            var tableBook = await _context.TableBooks
                .Include(t => t.Author)
                .Include(t => t.Category)
                .Include(t => t.Publisher)
                .Include(t => t.StoreOwner)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tableBook == null)
            {
                return NotFound();
            }

            return View(tableBook);
        }

        // POST: TableBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TableBooks == null)
            {
                return Problem("Entity set 'FptbookStoreTeam4Context.TableBooks'  is null.");
            }
            var tableBook = await _context.TableBooks.FindAsync(id);
            if (tableBook != null)
            {
                _context.TableBooks.Remove(tableBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableBookExists(string id)
        {
          return (_context.TableBooks?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
