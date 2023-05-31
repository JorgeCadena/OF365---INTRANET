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
    public class ReferenciasController : Controller
    {
        private readonly IntranetProdContext _context;

        public ReferenciasController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Referencias
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Referencias.Include(r => r.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Referencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Referencias == null)
            {
                return NotFound();
            }

            var referencia = await _context.Referencias
                .Include(r => r.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.ReCodigo == id);
            if (referencia == null)
            {
                return NotFound();
            }

            return View(referencia);
        }

        // GET: Referencias/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Referencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReCodigo,ReEmpresa,ReCargo,ReNombre,ReDireccion,ReTelefono,ReMail,ReTipo,ReRelacion,UsCodigo")] Referencia referencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", referencia.UsCodigo);
            return View(referencia);
        }

        // GET: Referencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Referencias == null)
            {
                return NotFound();
            }

            var referencia = await _context.Referencias.FindAsync(id);
            if (referencia == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", referencia.UsCodigo);
            return View(referencia);
        }

        // POST: Referencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReCodigo,ReEmpresa,ReCargo,ReNombre,ReDireccion,ReTelefono,ReMail,ReTipo,ReRelacion,UsCodigo")] Referencia referencia)
        {
            if (id != referencia.ReCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenciaExists(referencia.ReCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", referencia.UsCodigo);
            return View(referencia);
        }

        // GET: Referencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Referencias == null)
            {
                return NotFound();
            }

            var referencia = await _context.Referencias
                .Include(r => r.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.ReCodigo == id);
            if (referencia == null)
            {
                return NotFound();
            }

            return View(referencia);
        }

        // POST: Referencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Referencias == null)
            {
                return Problem("Entity set 'IntranetProdContext.Referencias'  is null.");
            }
            var referencia = await _context.Referencias.FindAsync(id);
            if (referencia != null)
            {
                _context.Referencias.Remove(referencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenciaExists(int id)
        {
          return _context.Referencias.Any(e => e.ReCodigo == id);
        }
    }
}
