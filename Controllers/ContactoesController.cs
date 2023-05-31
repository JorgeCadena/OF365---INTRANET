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
    public class ContactoesController : Controller
    {
        private readonly IntranetProdContext _context;

        public ContactoesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Contactoes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Contactos.Include(c => c.EmCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Contactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .Include(c => c.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CoCodigo == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactoes/Create
        public IActionResult Create()
        {
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo");
            return View();
        }

        // POST: Contactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoCodigo,CoNombre,CoApellido,CoEmpresa,CoTelefono,CoDireccion,CoPais,CoCreador,CoFecha,CoEstado,EmCodigo")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", contacto.EmCodigo);
            return View(contacto);
        }

        // GET: Contactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", contacto.EmCodigo);
            return View(contacto);
        }

        // POST: Contactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoCodigo,CoNombre,CoApellido,CoEmpresa,CoTelefono,CoDireccion,CoPais,CoCreador,CoFecha,CoEstado,EmCodigo")] Contacto contacto)
        {
            if (id != contacto.CoCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.CoCodigo))
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
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", contacto.EmCodigo);
            return View(contacto);
        }

        // GET: Contactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contactos == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .Include(c => c.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CoCodigo == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contactos == null)
            {
                return Problem("Entity set 'IntranetProdContext.Contactos'  is null.");
            }
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto != null)
            {
                _context.Contactos.Remove(contacto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
          return (_context.Contactos?.Any(e => e.CoCodigo == id)).GetValueOrDefault();
        }
    }
}
