using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yacht.Models;

namespace Yacht.Controllers
{
    public class DostupnostController : Controller
    {
        private readonly YachtContext _context;

        public DostupnostController(YachtContext context)
        {
            _context = context;
        }

        // GET: Dostupnost
        public async Task<IActionResult> Index()
        {
            var yachtContext = _context.Dostupnost.Include(d => d.Baza).Include(d => d.Model);
            return View(await yachtContext.ToListAsync());
        }

        // GET: Dostupnost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostupnost = await _context.Dostupnost
                .Include(d => d.Baza)
                .Include(d => d.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostupnost == null)
            {
                return NotFound();
            }

            return View(dostupnost);
        }

        // GET: Dostupnost/Create
        public IActionResult Create()
        {
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Naziv");
            ViewData["ModelId"] = new SelectList(_context.Tip, "Id", "Naziv");
            return View();
        }

        // POST: Dostupnost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelId,Naziv,BaseId,Availability")] Dostupnost dostupnost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dostupnost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Naziv", dostupnost.BaseId);
            ViewData["ModelId"] = new SelectList(_context.Tip, "Id", "Naziv", dostupnost.ModelId);
            return View(dostupnost);
        }

        // GET: Dostupnost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostupnost = await _context.Dostupnost.FindAsync(id);
            if (dostupnost == null)
            {
                return NotFound();
            }
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Naziv", dostupnost.BaseId);
            ViewData["ModelId"] = new SelectList(_context.Tip, "Id", "Naziv", dostupnost.ModelId);
            return View(dostupnost);
        }

        // POST: Dostupnost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelId,Naziv,BaseId,Availability")] Dostupnost dostupnost)
        {
            if (id != dostupnost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dostupnost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DostupnostExists(dostupnost.Id))
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
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Naziv", dostupnost.BaseId);
            ViewData["ModelId"] = new SelectList(_context.Tip, "Id", "Naziv", dostupnost.ModelId);
            return View(dostupnost);
        }

        // GET: Dostupnost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dostupnost = await _context.Dostupnost
                .Include(d => d.Baza)
                .Include(d => d.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dostupnost == null)
            {
                return NotFound();
            }

            return View(dostupnost);
        }

        // POST: Dostupnost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dostupnost = await _context.Dostupnost.FindAsync(id);
            _context.Dostupnost.Remove(dostupnost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DostupnostExists(int id)
        {
            return _context.Dostupnost.Any(e => e.Id == id);
        }
    }
}
