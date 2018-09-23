using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLinfolk.Data.Entities;
using NetCoreLinfolk.Data.LinfolkContext;

namespace NetCoreLinfolk.Controllers
{
    public class BookCoversController : Controller
    {
        private readonly LinfolkContext _context;

        public BookCoversController(LinfolkContext context)
        {
            _context = context;
        }

        // GET: BookCovers
        public async Task<IActionResult> Index()
        {
            var linfolkContext = _context.BookCovers.Include(b => b.Book);
            return View(await linfolkContext.ToListAsync());
        }

        // GET: BookCovers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCover = await _context.BookCovers
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCover == null)
            {
                return NotFound();
            }

            return View(bookCover);
        }

        // GET: BookCovers/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            return View();
        }

        // POST: BookCovers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,ModifiedDate,ModifiedBy")] BookCover bookCover)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCover);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookCover.BookId);
            return View(bookCover);
        }

        // GET: BookCovers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCover = await _context.BookCovers.FindAsync(id);
            if (bookCover == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookCover.BookId);
            return View(bookCover);
        }

        // POST: BookCovers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,ModifiedDate,ModifiedBy")] BookCover bookCover)
        {
            if (id != bookCover.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCover);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCoverExists(bookCover.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookCover.BookId);
            return View(bookCover);
        }

        // GET: BookCovers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCover = await _context.BookCovers
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCover == null)
            {
                return NotFound();
            }

            return View(bookCover);
        }

        // POST: BookCovers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCover = await _context.BookCovers.FindAsync(id);
            _context.BookCovers.Remove(bookCover);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCoverExists(int id)
        {
            return _context.BookCovers.Any(e => e.Id == id);
        }
    }
}
