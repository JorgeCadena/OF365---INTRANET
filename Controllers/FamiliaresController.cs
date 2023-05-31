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
    public class FamiliaresController : Controller
    {
        private readonly IntranetProdContext _context;

        public FamiliaresController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Familiares
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Familiares.Include(f => f.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Familiares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Familiares == null)
            {
                return NotFound();
            }

            var familiare = await _context.Familiares
                .Include(f => f.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.FaCodigo == id);
            if (familiare == null)
            {
                return NotFound();
            }

            return View(familiare);
        }

        // GET: Familiares/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Familiares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaCodigo,FaIdentificacion,FaNombres,FaRelacion,FaNacimiento,UsCodigo")] Familiare familiare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", familiare.UsCodigo);
            return View(familiare);
        }

        // GET: Familiares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Familiares == null)
            {
                return NotFound();
            }

            var familiare = await _context.Familiares.FindAsync(id);
            if (familiare == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", familiare.UsCodigo);
            return View(familiare);
        }

        // POST: Familiares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaCodigo,FaIdentificacion,FaNombres,FaRelacion,FaNacimiento,UsCodigo")] Familiare familiare)
        {
            if (id != familiare.FaCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliareExists(familiare.FaCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", familiare.UsCodigo);
            return View(familiare);
        }

        // GET: Familiares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Familiares == null)
            {
                return NotFound();
            }

            var familiare = await _context.Familiares
                .Include(f => f.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.FaCodigo == id);
            if (familiare == null)
            {
                return NotFound();
            }

            return View(familiare);
        }

        // POST: Familiares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Familiares == null)
            {
                return Problem("Entity set 'IntranetProdContext.Familiares'  is null.");
            }
            var familiare = await _context.Familiares.FindAsync(id);
            if (familiare != null)
            {
                _context.Familiares.Remove(familiare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliareExists(int id)
        {
          return _context.Familiares.Any(e => e.FaCodigo == id);
        }
    }
}
