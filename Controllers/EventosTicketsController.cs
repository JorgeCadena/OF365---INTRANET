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
    public class EventosTicketsController : Controller
    {
        private readonly IntranetProdContext _context;

        public EventosTicketsController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: EventosTickets
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.EventosTickets.Include(e => e.TicCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: EventosTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventosTickets == null)
            {
                return NotFound();
            }

            var eventosTicket = await _context.EventosTickets
                .Include(e => e.TicCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EvtCodigo == id);
            if (eventosTicket == null)
            {
                return NotFound();
            }

            return View(eventosTicket);
        }

        // GET: EventosTickets/Create
        public IActionResult Create()
        {
            ViewData["TicCodigo"] = new SelectList(_context.Tickets, "TicCodigo", "TicCodigo");
            return View();
        }

        // POST: EventosTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvtCodigo,EvtDescripcion,EvtResponsable,EvtObservacion,EvtFecha,EvtUsuario,EvtEmpresa,EvtUsCod,Id,TicCodigo")] EventosTicket eventosTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventosTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicCodigo"] = new SelectList(_context.Tickets, "TicCodigo", "TicCodigo", eventosTicket.TicCodigo);
            return View(eventosTicket);
        }

        // GET: EventosTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventosTickets == null)
            {
                return NotFound();
            }

            var eventosTicket = await _context.EventosTickets.FindAsync(id);
            if (eventosTicket == null)
            {
                return NotFound();
            }
            ViewData["TicCodigo"] = new SelectList(_context.Tickets, "TicCodigo", "TicCodigo", eventosTicket.TicCodigo);
            return View(eventosTicket);
        }

        // POST: EventosTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvtCodigo,EvtDescripcion,EvtResponsable,EvtObservacion,EvtFecha,EvtUsuario,EvtEmpresa,EvtUsCod,Id,TicCodigo")] EventosTicket eventosTicket)
        {
            if (id != eventosTicket.EvtCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventosTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosTicketExists(eventosTicket.EvtCodigo))
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
            ViewData["TicCodigo"] = new SelectList(_context.Tickets, "TicCodigo", "TicCodigo", eventosTicket.TicCodigo);
            return View(eventosTicket);
        }

        // GET: EventosTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventosTickets == null)
            {
                return NotFound();
            }

            var eventosTicket = await _context.EventosTickets
                .Include(e => e.TicCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EvtCodigo == id);
            if (eventosTicket == null)
            {
                return NotFound();
            }

            return View(eventosTicket);
        }

        // POST: EventosTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventosTickets == null)
            {
                return Problem("Entity set 'IntranetProdContext.EventosTickets'  is null.");
            }
            var eventosTicket = await _context.EventosTickets.FindAsync(id);
            if (eventosTicket != null)
            {
                _context.EventosTickets.Remove(eventosTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventosTicketExists(int id)
        {
          return _context.EventosTickets.Any(e => e.EvtCodigo == id);
        }
    }
}
