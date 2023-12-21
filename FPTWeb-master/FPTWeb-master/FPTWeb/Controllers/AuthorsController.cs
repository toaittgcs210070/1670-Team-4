﻿using FPTWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FPTWeb.Controllers
{
	public class AuthorsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AuthorsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Authors
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
		{
			return _context.Authors != null ?
						View(await _context.Authors.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Authors'  is null.");
		}

		// GET: Authors/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Authors == null)
			{
				return NotFound();
			}

			var author = await _context.Authors
				.FirstOrDefaultAsync(m => m.AuthorId == id);
			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		// GET: Authors/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Authors/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("AuthorId,AuthorName,AuthorEmail,AuthorPhoto,Birthdate")] Author author)
		{
			if (ModelState.IsValid)
			{
				_context.Add(author);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(author);
		}

		// GET: Authors/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Authors == null)
			{
				return NotFound();
			}

			var author = await _context.Authors.FindAsync(id);
			if (author == null)
			{
				return NotFound();
			}
			return View(author);
		}

		// POST: Authors/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName,AuthorEmail,AuthorPhoto,Birthdate")] Author author)
		{
			if (id != author.AuthorId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(author);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AuthorExists(author.AuthorId))
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
			return View(author);
		}

		// GET: Authors/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Authors == null)
			{
				return NotFound();
			}

			var author = await _context.Authors
				.FirstOrDefaultAsync(m => m.AuthorId == id);
			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		// POST: Authors/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Authors == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Authors'  is null.");
			}
			var author = await _context.Authors.FindAsync(id);
			if (author != null)
			{
				_context.Authors.Remove(author);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		[Authorize(Roles = "Admin")]
		private bool AuthorExists(int id)
		{
			return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
		}
	}
}
