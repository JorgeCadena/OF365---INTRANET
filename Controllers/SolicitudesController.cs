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
    public class SolicitudesController : Controller
    {
        private readonly IntranetProdContext _context;

        public SolicitudesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Solicitudes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Solicitudes.Include(s => s.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes
                .Include(s => s.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.SoCodigo == id);
            if (solicitude == null)
            {
                return NotFound();
            }

            return View(solicitude);
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoCodigo,SoTipo,SoOtros,SoMotivo,SoDetalle,SoPrestamoCantidad,SoPrestamoCuotas,SoPrestamoValor,SoPermisoDesde,SoPermisoHasta,SoAusenciaDesde,SoAusenciaHasta,SoAusenciaRetorno,SoPersonalCargo,SoPersonalCupos,SoPersonalSueldo,SoPersonalContrato,SoPersonalArea,SoPersonalSucursal,SoPersonalMotivo,SoPersonalReemplaza,SoPersonalTiempo,SoPersonalJornada,SoPersonalInicio,SoPersonalObservacion,SoPersonalJefe,SoEstado,SoFecha,UsCodigo")] Solicitude solicitude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", solicitude.UsCodigo);
            return View(solicitude);
        }

        // GET: Solicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", solicitude.UsCodigo);
            return View(solicitude);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoCodigo,SoTipo,SoOtros,SoMotivo,SoDetalle,SoPrestamoCantidad,SoPrestamoCuotas,SoPrestamoValor,SoPermisoDesde,SoPermisoHasta,SoAusenciaDesde,SoAusenciaHasta,SoAusenciaRetorno,SoPersonalCargo,SoPersonalCupos,SoPersonalSueldo,SoPersonalContrato,SoPersonalArea,SoPersonalSucursal,SoPersonalMotivo,SoPersonalReemplaza,SoPersonalTiempo,SoPersonalJornada,SoPersonalInicio,SoPersonalObservacion,SoPersonalJefe,SoEstado,SoFecha,UsCodigo")] Solicitude solicitude)
        {
            if (id != solicitude.SoCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudeExists(solicitude.SoCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", solicitude.UsCodigo);
            return View(solicitude);
        }

        // GET: Solicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes
                .Include(s => s.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.SoCodigo == id);
            if (solicitude == null)
            {
                return NotFound();
            }

            return View(solicitude);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitudes == null)
            {
                return Problem("Entity set 'IntranetProdContext.Solicitudes'  is null.");
            }
            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude != null)
            {
                _context.Solicitudes.Remove(solicitude);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudeExists(int id)
        {
          return _context.Solicitudes.Any(e => e.SoCodigo == id);
        }
    }
}
