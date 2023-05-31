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
    public class DirectoriosController : Controller
    {
        private readonly IntranetProdContext _context;

        public DirectoriosController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Directorios
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Directorios.Include(d => d.EmCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Directorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Directorios == null)
            {
                return NotFound();
            }

            var directorio = await _context.Directorios
                .Include(d => d.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.DirCodigo == id);
            if (directorio == null)
            {
                return NotFound();
            }

            return View(directorio);
        }

        // GET: Directorios/Create
        public IActionResult Create()
        {
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo");
            return View();
        }

        // POST: Directorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirCodigo,DirCliente,DirArea,DirIndustria,DirDetalle,DirCosto,DirInvolucrados,DirEncargados,DirMiembros,DirOtros,DirInicio,DirFin,DirAdicional,DirCreado,DirModificado,DirRevisado,DirConfidencial,DirDescripcion,DirFechaIngreso,DirNumeroCaso,EmCodigo")] Directorio directorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", directorio.EmCodigo);
            return View(directorio);
        }

        // GET: Directorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Directorios == null)
            {
                return NotFound();
            }

            var directorio = await _context.Directorios.FindAsync(id);
            if (directorio == null)
            {
                return NotFound();
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", directorio.EmCodigo);
            return View(directorio);
        }

        // POST: Directorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirCodigo,DirCliente,DirArea,DirIndustria,DirDetalle,DirCosto,DirInvolucrados,DirEncargados,DirMiembros,DirOtros,DirInicio,DirFin,DirAdicional,DirCreado,DirModificado,DirRevisado,DirConfidencial,DirDescripcion,DirFechaIngreso,DirNumeroCaso,EmCodigo")] Directorio directorio)
        {
            if (id != directorio.DirCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorioExists(directorio.DirCodigo))
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
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", directorio.EmCodigo);
            return View(directorio);
        }

        // GET: Directorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Directorios == null)
            {
                return NotFound();
            }

            var directorio = await _context.Directorios
                .Include(d => d.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.DirCodigo == id);
            if (directorio == null)
            {
                return NotFound();
            }

            return View(directorio);
        }

        // POST: Directorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Directorios == null)
            {
                return Problem("Entity set 'IntranetProdContext.Directorios'  is null.");
            }
            var directorio = await _context.Directorios.FindAsync(id);
            if (directorio != null)
            {
                _context.Directorios.Remove(directorio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorioExists(int id)
        {
          return _context.Directorios.Any(e => e.DirCodigo == id);
        }
    }
}
