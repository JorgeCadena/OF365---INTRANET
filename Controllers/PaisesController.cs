using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTRANET_CR.Models;

namespace INTRANET_CR.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IntranetProdContext _context;

        public PaisesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Paises
        public async Task<IActionResult> Index()
        {
              return View(await _context.Paises.ToListAsync());
        }

        // GET: Paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paise = await _context.Paises
                .FirstOrDefaultAsync(m => m.PaCodigo == id);
            if (paise == null)
            {
                return NotFound();
            }

            return View(paise);
        }

        // GET: Paises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaCodigo,PaPre,PaNombre")] Paise paise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paise);
        }

        // GET: Paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paise = await _context.Paises.FindAsync(id);
            if (paise == null)
            {
                return NotFound();
            }
            return View(paise);
        }

        // POST: Paises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaCodigo,PaPre,PaNombre")] Paise paise)
        {
            if (id != paise.PaCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaiseExists(paise.PaCodigo))
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
            return View(paise);
        }

        // GET: Paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paises == null)
            {
                return NotFound();
            }

            var paise = await _context.Paises
                .FirstOrDefaultAsync(m => m.PaCodigo == id);
            if (paise == null)
            {
                return NotFound();
            }

            return View(paise);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paises == null)
            {
                return Problem("Entity set 'IntranetProdContext.Paises'  is null.");
            }
            var paise = await _context.Paises.FindAsync(id);
            if (paise != null)
            {
                _context.Paises.Remove(paise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaiseExists(int id)
        {
          return _context.Paises.Any(e => e.PaCodigo == id);
        }
    }
}
