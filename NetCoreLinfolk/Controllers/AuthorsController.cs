using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLinfolk.Data.Entities;
using NetCoreLinfolk.Data.LinfolkContext;

namespace NetCoreLinfolk.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly LinfolkContext _context;
        private readonly UserManager<Author> _usermanager;

        public AuthorsController(LinfolkContext context, UserManager<Author> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var linfolkContext = _context.Authors.Include(a => a.City);
            return View(await linfolkContext.ToListAsync());
        }
        
        // GET: Authors/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,JoinedDate,IsActivated,CityId,Street")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", author.CityId);
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", author.CityId);
            return View(author);
        }

    }
}
