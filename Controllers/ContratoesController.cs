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
    public class ContratoesController : Controller
    {
        private readonly IntranetProdContext _context;

        public ContratoesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Contratoes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Contratos.Include(c => c.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Contratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CoCodigo == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratoes/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsCodigo");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoCodigo,CoTipo,CoInicio,CoFin,CoSueldo,CoBono,CoMotivoSalida,CoLiquidacion,CoObservacion,CoEstado,CoUbicacion,CoExtension,UsCodigo")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsCodigo", contrato.UsCodigo);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsCodigo", contrato.UsCodigo);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoCodigo,CoTipo,CoInicio,CoFin,CoSueldo,CoBono,CoMotivoSalida,CoLiquidacion,CoObservacion,CoEstado,CoUbicacion,CoExtension,UsCodigo")] Contrato contrato)
        {
            if (id != contrato.CoCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.CoCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsCodigo", contrato.UsCodigo);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CoCodigo == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contratos == null)
            {
                return Problem("Entity set 'IntranetProdContext.Contratos'  is null.");
            }
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
          return (_context.Contratos?.Any(e => e.CoCodigo == id)).GetValueOrDefault();
        }
    }
}
