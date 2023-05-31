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
    public class EducacionsController : Controller
    {
        private readonly IntranetProdContext _context;

        public EducacionsController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Educacions
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Educacions.Include(e => e.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Educacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Educacions == null)
            {
                return NotFound();
            }

            var educacion = await _context.Educacions
                .Include(e => e.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EdCodigo == id);
            if (educacion == null)
            {
                return NotFound();
            }

            return View(educacion);
        }

        // GET: Educacions/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Educacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EdCodigo,EdTipo,EdNivel,EdPlantel,EdCiudad,EdInicio,EdFin,EdTitulo,EdFinalizado,EdDescripcion,EdEstado,UsCodigo")] Educacion educacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", educacion.UsCodigo);
            return View(educacion);
        }

        // GET: Educacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Educacions == null)
            {
                return NotFound();
            }

            var educacion = await _context.Educacions.FindAsync(id);
            if (educacion == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", educacion.UsCodigo);
            return View(educacion);
        }

        // POST: Educacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EdCodigo,EdTipo,EdNivel,EdPlantel,EdCiudad,EdInicio,EdFin,EdTitulo,EdFinalizado,EdDescripcion,EdEstado,UsCodigo")] Educacion educacion)
        {
            if (id != educacion.EdCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducacionExists(educacion.EdCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", educacion.UsCodigo);
            return View(educacion);
        }

        // GET: Educacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Educacions == null)
            {
                return NotFound();
            }

            var educacion = await _context.Educacions
                .Include(e => e.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.EdCodigo == id);
            if (educacion == null)
            {
                return NotFound();
            }

            return View(educacion);
        }

        // POST: Educacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Educacions == null)
            {
                return Problem("Entity set 'IntranetProdContext.Educacions'  is null.");
            }
            var educacion = await _context.Educacions.FindAsync(id);
            if (educacion != null)
            {
                _context.Educacions.Remove(educacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducacionExists(int id)
        {
          return _context.Educacions.Any(e => e.EdCodigo == id);
        }
    }
}
