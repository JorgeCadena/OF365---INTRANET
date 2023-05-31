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
    public class SubTarifasController : Controller
    {
        private readonly IntranetProdContext _context;

        public SubTarifasController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: SubTarifas
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.SubTarifas.Include(s => s.TaCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: SubTarifas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubTarifas == null)
            {
                return NotFound();
            }

            var subTarifa = await _context.SubTarifas
                .Include(s => s.TaCodigoNavigation)
                .FirstOrDefaultAsync(m => m.SutCodigo == id);
            if (subTarifa == null)
            {
                return NotFound();
            }

            return View(subTarifa);
        }

        // GET: SubTarifas/Create
        public IActionResult Create()
        {
            ViewData["TaCodigo"] = new SelectList(_context.Tarifas, "TaCodigo", "TaCodigo");
            return View();
        }

        // POST: SubTarifas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SutCodigo,SutCategoria,SutTarifa,SutMoneda,SutEstado,TaCodigo")] SubTarifa subTarifa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subTarifa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaCodigo"] = new SelectList(_context.Tarifas, "TaCodigo", "TaCodigo", subTarifa.TaCodigo);
            return View(subTarifa);
        }

        // GET: SubTarifas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubTarifas == null)
            {
                return NotFound();
            }

            var subTarifa = await _context.SubTarifas.FindAsync(id);
            if (subTarifa == null)
            {
                return NotFound();
            }
            ViewData["TaCodigo"] = new SelectList(_context.Tarifas, "TaCodigo", "TaCodigo", subTarifa.TaCodigo);
            return View(subTarifa);
        }

        // POST: SubTarifas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SutCodigo,SutCategoria,SutTarifa,SutMoneda,SutEstado,TaCodigo")] SubTarifa subTarifa)
        {
            if (id != subTarifa.SutCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subTarifa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubTarifaExists(subTarifa.SutCodigo))
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
            ViewData["TaCodigo"] = new SelectList(_context.Tarifas, "TaCodigo", "TaCodigo", subTarifa.TaCodigo);
            return View(subTarifa);
        }

        // GET: SubTarifas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubTarifas == null)
            {
                return NotFound();
            }

            var subTarifa = await _context.SubTarifas
                .Include(s => s.TaCodigoNavigation)
                .FirstOrDefaultAsync(m => m.SutCodigo == id);
            if (subTarifa == null)
            {
                return NotFound();
            }

            return View(subTarifa);
        }

        // POST: SubTarifas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubTarifas == null)
            {
                return Problem("Entity set 'IntranetProdContext.SubTarifas'  is null.");
            }
            var subTarifa = await _context.SubTarifas.FindAsync(id);
            if (subTarifa != null)
            {
                _context.SubTarifas.Remove(subTarifa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubTarifaExists(int id)
        {
          return _context.SubTarifas.Any(e => e.SutCodigo == id);
        }
    }
}
