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
    public class ContactoFacturacionsController : Controller
    {
        private readonly IntranetProdContext _context;

        public ContactoFacturacionsController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: ContactoFacturacions
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.ContactoFacturacions.Include(c => c.CliCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: ContactoFacturacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactoFacturacions == null)
            {
                return NotFound();
            }

            var contactoFacturacion = await _context.ContactoFacturacions
                .Include(c => c.CliCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CofCodigo == id);
            if (contactoFacturacion == null)
            {
                return NotFound();
            }

            return View(contactoFacturacion);
        }

        // GET: ContactoFacturacions/Create
        public IActionResult Create()
        {
            ViewData["CliCodigo"] = new SelectList(_context.Clientes, "CliCodigo", "CliCodigo");
            return View();
        }

        // POST: ContactoFacturacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CofCodigo,CofNombre,CofTelefono,CofMail,CofDireccion,CofEstado,CliCodigo")] ContactoFacturacion contactoFacturacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactoFacturacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CliCodigo"] = new SelectList(_context.Clientes, "CliCodigo", "CliCodigo", contactoFacturacion.CliCodigo);
            return View(contactoFacturacion);
        }

        // GET: ContactoFacturacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactoFacturacions == null)
            {
                return NotFound();
            }

            var contactoFacturacion = await _context.ContactoFacturacions.FindAsync(id);
            if (contactoFacturacion == null)
            {
                return NotFound();
            }
            ViewData["CliCodigo"] = new SelectList(_context.Clientes, "CliCodigo", "CliCodigo", contactoFacturacion.CliCodigo);
            return View(contactoFacturacion);
        }

        // POST: ContactoFacturacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CofCodigo,CofNombre,CofTelefono,CofMail,CofDireccion,CofEstado,CliCodigo")] ContactoFacturacion contactoFacturacion)
        {
            if (id != contactoFacturacion.CofCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactoFacturacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoFacturacionExists(contactoFacturacion.CofCodigo))
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
            ViewData["CliCodigo"] = new SelectList(_context.Clientes, "CliCodigo", "CliCodigo", contactoFacturacion.CliCodigo);
            return View(contactoFacturacion);
        }

        // GET: ContactoFacturacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactoFacturacions == null)
            {
                return NotFound();
            }

            var contactoFacturacion = await _context.ContactoFacturacions
                .Include(c => c.CliCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CofCodigo == id);
            if (contactoFacturacion == null)
            {
                return NotFound();
            }

            return View(contactoFacturacion);
        }

        // POST: ContactoFacturacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactoFacturacions == null)
            {
                return Problem("Entity set 'IntranetProdContext.ContactoFacturacions'  is null.");
            }
            var contactoFacturacion = await _context.ContactoFacturacions.FindAsync(id);
            if (contactoFacturacion != null)
            {
                _context.ContactoFacturacions.Remove(contactoFacturacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoFacturacionExists(int id)
        {
          return (_context.ContactoFacturacions?.Any(e => e.CofCodigo == id)).GetValueOrDefault();
        }
    }
}
