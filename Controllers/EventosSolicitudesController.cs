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
    public class EventosSolicitudesController : Controller
    {
        private readonly IntranetProdContext _context;

        public EventosSolicitudesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: EventosSolicitudes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.EventosSolicitudes.Include(e => e.SoCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: EventosSolicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventosSolicitudes == null)
            {
                return NotFound();
            }

            var eventosSolicitude = await _context.EventosSolicitudes
                .Include(e => e.SoCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EvsCodigo == id);
            if (eventosSolicitude == null)
            {
                return NotFound();
            }

            return View(eventosSolicitude);
        }

        // GET: EventosSolicitudes/Create
        public IActionResult Create()
        {
            ViewData["SoCodigo"] = new SelectList(_context.Solicitudes, "SoCodigo", "SoCodigo");
            return View();
        }

        // POST: EventosSolicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvsCodigo,EvsDescripcion,EvsResponsable,EvsObservacion,EvsFecha,SoCodigo")] EventosSolicitude eventosSolicitude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventosSolicitude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SoCodigo"] = new SelectList(_context.Solicitudes, "SoCodigo", "SoCodigo", eventosSolicitude.SoCodigo);
            return View(eventosSolicitude);
        }

        // GET: EventosSolicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventosSolicitudes == null)
            {
                return NotFound();
            }

            var eventosSolicitude = await _context.EventosSolicitudes.FindAsync(id);
            if (eventosSolicitude == null)
            {
                return NotFound();
            }
            ViewData["SoCodigo"] = new SelectList(_context.Solicitudes, "SoCodigo", "SoCodigo", eventosSolicitude.SoCodigo);
            return View(eventosSolicitude);
        }

        // POST: EventosSolicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvsCodigo,EvsDescripcion,EvsResponsable,EvsObservacion,EvsFecha,SoCodigo")] EventosSolicitude eventosSolicitude)
        {
            if (id != eventosSolicitude.EvsCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventosSolicitude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosSolicitudeExists(eventosSolicitude.EvsCodigo))
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
            ViewData["SoCodigo"] = new SelectList(_context.Solicitudes, "SoCodigo", "SoCodigo", eventosSolicitude.SoCodigo);
            return View(eventosSolicitude);
        }

        // GET: EventosSolicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventosSolicitudes == null)
            {
                return NotFound();
            }

            var eventosSolicitude = await _context.EventosSolicitudes
                .Include(e => e.SoCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EvsCodigo == id);
            if (eventosSolicitude == null)
            {
                return NotFound();
            }

            return View(eventosSolicitude);
        }

        // POST: EventosSolicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventosSolicitudes == null)
            {
                return Problem("Entity set 'IntranetProdContext.EventosSolicitudes'  is null.");
            }
            var eventosSolicitude = await _context.EventosSolicitudes.FindAsync(id);
            if (eventosSolicitude != null)
            {
                _context.EventosSolicitudes.Remove(eventosSolicitude);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventosSolicitudeExists(int id)
        {
          return _context.EventosSolicitudes.Any(e => e.EvsCodigo == id);
        }
    }
}
