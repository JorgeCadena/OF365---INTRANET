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
    public class EventosAsuntoesController : Controller
    {
        private readonly IntranetProdContext _context;

        public EventosAsuntoesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: EventosAsuntoes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.EventosAsuntos.Include(e => e.AsuCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: EventosAsuntoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventosAsuntos == null)
            {
                return NotFound();
            }

            var eventosAsunto = await _context.EventosAsuntos
                .Include(e => e.AsuCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EvaCodigo == id);
            if (eventosAsunto == null)
            {
                return NotFound();
            }

            return View(eventosAsunto);
        }

        // GET: EventosAsuntoes/Create
        public IActionResult Create()
        {
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuTitulo");
            return View();
        }

        // POST: EventosAsuntoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaCodigo,EvaDescripcion,EvaResponsable,EvaObservacion,EvaFecha,AsuCodigo")] EventosAsunto eventosAsunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventosAsunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuTitulo", eventosAsunto.AsuCodigo);
            return View(eventosAsunto);
        }

        // GET: EventosAsuntoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventosAsuntos == null)
            {
                return NotFound();
            }

            var eventosAsunto = await _context.EventosAsuntos.FindAsync(id);
            if (eventosAsunto == null)
            {
                return NotFound();
            }
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuTitulo", eventosAsunto.AsuCodigo);
            return View(eventosAsunto);
        }

        // POST: EventosAsuntoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaCodigo,EvaDescripcion,EvaResponsable,EvaObservacion,EvaFecha,AsuCodigo")] EventosAsunto eventosAsunto)
        {
            if (id != eventosAsunto.EvaCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventosAsunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosAsuntoExists(eventosAsunto.EvaCodigo))
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
            ViewData["AsuCodigo"] = new SelectList(_context.Asuntos, "AsuCodigo", "AsuTitulo", eventosAsunto.AsuCodigo);
            return View(eventosAsunto);
        }

        // GET: EventosAsuntoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventosAsuntos == null)
            {
                return NotFound();
            }

            var eventosAsunto = await _context.EventosAsuntos
                .Include(e => e.AsuCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EvaCodigo == id);
            if (eventosAsunto == null)
            {
                return NotFound();
            }

            return View(eventosAsunto);
        }

        // POST: EventosAsuntoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventosAsuntos == null)
            {
                return Problem("Entity set 'IntranetProdContext.EventosAsuntos'  is null.");
            }
            var eventosAsunto = await _context.EventosAsuntos.FindAsync(id);
            if (eventosAsunto != null)
            {
                _context.EventosAsuntos.Remove(eventosAsunto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventosAsuntoExists(int id)
        {
          return _context.EventosAsuntos.Any(e => e.EvaCodigo == id);
        }
    }
}
