using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Preparation.IService;
using Preparation.Models;

namespace Preparation.Controllers
{
    public class ParentsController : Controller
    {

        IServiceParents _isp;
        public ParentsController (IServiceParents isp)
        {
            _isp = isp;
        }
        // GET: Parents
        public IActionResult Index()
        {
            var data = _isp.GetDataXMl().Where(x=>x.Mere == "RANDRIA").ToList();
            return View(_isp.FindAll());
        }

        public IEnumerable<Parents> AllParents()
        {
            return _isp.FindAll();
        }

        // GET: Parents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _isp.FindAll() == null)
            {
                return NotFound();
            }

            var parents = await _isp.FindAll()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parents == null)
            {
                return NotFound();
            }

            return View(parents);
        }

        // GET: Parents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pere,Mere,Adresse")] Parents parents)
        {
            if (ModelState.IsValid)
            {
                _isp.Create(parents);
                return RedirectToAction(nameof(Index));
            }
            return View(parents);
        }

        // GET: Parents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _isp.FindAll() == null)
            {
                return NotFound();
            }

            var parents = await _isp.FindAll().FirstOrDefaultAsync(m => m.Id == id);
            if (parents == null)
            {
                return NotFound();
            }
            return View(parents);
        }

        // POST: Parents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Pere,Mere,Adresse")] Parents parents)
        {
            if (id != parents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _isp.Update(parents);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentsExists(parents.Id))
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
            return View(parents);
        }

        // GET: Parents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _isp.FindAll() == null)
            {
                return NotFound();
            }

            var parents = await _isp.FindAll().FirstOrDefaultAsync(m => m.Id == id);
            if (parents == null)
            {
                return NotFound();
            }

            return View(parents);
        }

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_isp.FindAll() == null)
            {
                return Problem("Entity set 'PreparationContext.Parents'  is null.");
            }
            var parents = await _isp.FindAll().FirstOrDefaultAsync(m => m.Id == id);
            if (parents != null)
            {
                _isp.Delete(parents);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ParentsExists(int? id)
        {
          return _isp.FindAll().Any(e => e.Id == id);
        }
    }
}
