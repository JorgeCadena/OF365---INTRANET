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
    public class HitoesController : Controller
    {
        private readonly IntranetProdContext _context;

        public HitoesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Hitoes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Hitos.Include(h => h.AsuCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Hitoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hitos == null)
            {
                return NotFound();
            }

            var hito = await _context.Hitos
                .Include(h => h.AsuCodigoNavigation)
                .FirstOrDefaultAsync(m => m.HiCodigo == id);
            if (hito == null)
            {
                return NotFound();
            }

            return View(hito);
        }

        // GET: Hitoes/Create
        public IActionResult Create()
        {
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuCodigo");
            return View();
        }

        // POST: Hitoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HiCodigo,HiFecha,HiDescripcion,HiValor,HiObservacion,HiFechaRecordatorio,AsuCodigo")] Hito hito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuCodigo", hito.AsuCodigo);
            return View(hito);
        }

        // GET: Hitoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hitos == null)
            {
                return NotFound();
            }

            var hito = await _context.Hitos.FindAsync(id);
            if (hito == null)
            {
                return NotFound();
            }
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuCodigo", hito.AsuCodigo);
            return View(hito);
        }

        // POST: Hitoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HiCodigo,HiFecha,HiDescripcion,HiValor,HiObservacion,HiFechaRecordatorio,AsuCodigo")] Hito hito)
        {
            if (id != hito.HiCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HitoExists(hito.HiCodigo))
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
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuCodigo", hito.AsuCodigo);
            return View(hito);
        }

        // GET: Hitoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hitos == null)
            {
                return NotFound();
            }

            var hito = await _context.Hitos
                .Include(h => h.AsuCodigoNavigation)
                .FirstOrDefaultAsync(m => m.HiCodigo == id);
            if (hito == null)
            {
                return NotFound();
            }

            return View(hito);
        }

        // POST: Hitoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hitos == null)
            {
                return Problem("Entity set 'IntranetProdContext.Hitos'  is null.");
            }
            var hito = await _context.Hitos.FindAsync(id);
            if (hito != null)
            {
                _context.Hitos.Remove(hito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HitoExists(int id)
        {
          return (_context.Hitos?.Any(e => e.HiCodigo == id)).GetValueOrDefault();
        }
    }
}
