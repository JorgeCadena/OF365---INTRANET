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
    public class ExperienciumsController : Controller
    {
        private readonly IntranetProdContext _context;

        public ExperienciumsController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Experienciums
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Experiencia.Include(e => e.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Experienciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Experiencia == null)
            {
                return NotFound();
            }

            var experiencium = await _context.Experiencia
                .Include(e => e.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.ExCodigo == id);
            if (experiencium == null)
            {
                return NotFound();
            }

            return View(experiencium);
        }

        // GET: Experienciums/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Experienciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExCodigo,ExEmpresa,ExDireccion,ExTelefono,ExCargoinicial,ExSueldoinicial,ExCargofinal,ExSueldofinal,ExMotivorenuncia,ExEstado,ExDescripcion,ExTiempo,UsCodigo")] Experiencium experiencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", experiencium.UsCodigo);
            return View(experiencium);
        }

        // GET: Experienciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Experiencia == null)
            {
                return NotFound();
            }

            var experiencium = await _context.Experiencia.FindAsync(id);
            if (experiencium == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", experiencium.UsCodigo);
            return View(experiencium);
        }

        // POST: Experienciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExCodigo,ExEmpresa,ExDireccion,ExTelefono,ExCargoinicial,ExSueldoinicial,ExCargofinal,ExSueldofinal,ExMotivorenuncia,ExEstado,ExDescripcion,ExTiempo,UsCodigo")] Experiencium experiencium)
        {
            if (id != experiencium.ExCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciumExists(experiencium.ExCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", experiencium.UsCodigo);
            return View(experiencium);
        }

        // GET: Experienciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Experiencia == null)
            {
                return NotFound();
            }

            var experiencium = await _context.Experiencia
                .Include(e => e.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.ExCodigo == id);
            if (experiencium == null)
            {
                return NotFound();
            }

            return View(experiencium);
        }

        // POST: Experienciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Experiencia == null)
            {
                return Problem("Entity set 'IntranetProdContext.Experiencia'  is null.");
            }
            var experiencium = await _context.Experiencia.FindAsync(id);
            if (experiencium != null)
            {
                _context.Experiencia.Remove(experiencium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciumExists(int id)
        {
          return _context.Experiencia.Any(e => e.ExCodigo == id);
        }
    }
}
