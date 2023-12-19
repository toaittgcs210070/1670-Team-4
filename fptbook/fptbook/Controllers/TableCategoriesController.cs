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
    public class TableCategoriesController : Controller
    {
        private readonly FptbookStoreTeam4Context _context;

        public TableCategoriesController(FptbookStoreTeam4Context context)
        {
            _context = context;
        }

        // GET: TableCategories
        public async Task<IActionResult> Index()
        {
              return _context.TableCategories != null ? 
                          View(await _context.TableCategories.ToListAsync()) :
                          Problem("Entity set 'FptbookStoreTeam4Context.TableCategories'  is null.");
        }

        // GET: TableCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TableCategories == null)
            {
                return NotFound();
            }

            var tableCategory = await _context.TableCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tableCategory == null)
            {
                return NotFound();
            }

            return View(tableCategory);
        }

        // GET: TableCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDetail")] TableCategory tableCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableCategory);
        }

        // GET: TableCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TableCategories == null)
            {
                return NotFound();
            }

            var tableCategory = await _context.TableCategories.FindAsync(id);
            if (tableCategory == null)
            {
                return NotFound();
            }
            return View(tableCategory);
        }

        // POST: TableCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryDetail")] TableCategory tableCategory)
        {
            if (id != tableCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableCategoryExists(tableCategory.CategoryId))
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
            return View(tableCategory);
        }

        // GET: TableCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TableCategories == null)
            {
                return NotFound();
            }

            var tableCategory = await _context.TableCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tableCategory == null)
            {
                return NotFound();
            }

            return View(tableCategory);
        }

        // POST: TableCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TableCategories == null)
            {
                return Problem("Entity set 'FptbookStoreTeam4Context.TableCategories'  is null.");
            }
            var tableCategory = await _context.TableCategories.FindAsync(id);
            if (tableCategory != null)
            {
                _context.TableCategories.Remove(tableCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableCategoryExists(int id)
        {
          return (_context.TableCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
