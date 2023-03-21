using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Preparation.Models;

namespace Preparation.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly Context _context;

        public PersonnesController(Context context)
        {
            _context = context;
        }

        // GET: Personnes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Personnes.ToListAsync());
        }

        // GET: Personnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personnes == null)
            {
                return NotFound();
            }

            var personnes = await _context.Personnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnes == null)
            {
                return NotFound();
            }

            return View(personnes);
        }

        // GET: Personnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Age,Adresse,Fonction,Id_Parent")] Personnes personnes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personnes);
        }

        // GET: Personnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personnes == null)
            {
                return NotFound();
            }

            var personnes = await _context.Personnes.FindAsync(id);
            if (personnes == null)
            {
                return NotFound();
            }
            return View(personnes);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Age,Adresse,Fonction,Id_Parent")] Personnes personnes)
        {
            if (id != personnes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnesExists(personnes.Id))
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
            return View(personnes);
        }

        // GET: Personnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personnes == null)
            {
                return NotFound();
            }

            var personnes = await _context.Personnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnes == null)
            {
                return NotFound();
            }

            return View(personnes);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personnes == null)
            {
                return Problem("Entity set 'PreparationContext.Personnes'  is null.");
            }
            var personnes = await _context.Personnes.FindAsync(id);
            if (personnes != null)
            {
                _context.Personnes.Remove(personnes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonnesExists(int id)
        {
          return _context.Personnes.Any(e => e.Id == id);
        }
    }
}
