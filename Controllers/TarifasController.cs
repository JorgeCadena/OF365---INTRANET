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
    public class TarifasController : Controller
    {
        private readonly IntranetProdContext _context;

        public TarifasController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Tarifas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tarifas.ToListAsync());
        }

        // GET: Tarifas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarifas == null)
            {
                return NotFound();
            }

            var tarifa = await _context.Tarifas
                .FirstOrDefaultAsync(m => m.TaCodigo == id);
            if (tarifa == null)
            {
                return NotFound();
            }

            return View(tarifa);
        }

        // GET: Tarifas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarifas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaCodigo,TaNombre,TaEstado")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarifa);
        }

        // GET: Tarifas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarifas == null)
            {
                return NotFound();
            }

            var tarifa = await _context.Tarifas.FindAsync(id);
            if (tarifa == null)
            {
                return NotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaCodigo,TaNombre,TaEstado")] Tarifa tarifa)
        {
            if (id != tarifa.TaCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifaExists(tarifa.TaCodigo))
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
            return View(tarifa);
        }

        // GET: Tarifas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarifas == null)
            {
                return NotFound();
            }

            var tarifa = await _context.Tarifas
                .FirstOrDefaultAsync(m => m.TaCodigo == id);
            if (tarifa == null)
            {
                return NotFound();
            }

            return View(tarifa);
        }

        // POST: Tarifas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarifas == null)
            {
                return Problem("Entity set 'IntranetProdContext.Tarifas'  is null.");
            }
            var tarifa = await _context.Tarifas.FindAsync(id);
            if (tarifa != null)
            {
                _context.Tarifas.Remove(tarifa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifaExists(int id)
        {
          return _context.Tarifas.Any(e => e.TaCodigo == id);
        }
    }
}
