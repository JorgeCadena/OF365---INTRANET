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
    public class DocumentoesController : Controller
    {
        private readonly IntranetProdContext _context;

        public DocumentoesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Documentoes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Documentos.Include(d => d.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Documentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documentos == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .Include(d => d.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.DocCodigo == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: Documentoes/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Documentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocCodigo,DocTipo,DocDescripcion,DocPeriodo,DocEstado,DocFecha,UsCodigo")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", documento.UsCodigo);
            return View(documento);
        }

        // GET: Documentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documentos == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", documento.UsCodigo);
            return View(documento);
        }

        // POST: Documentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocCodigo,DocTipo,DocDescripcion,DocPeriodo,DocEstado,DocFecha,UsCodigo")] Documento documento)
        {
            if (id != documento.DocCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(documento.DocCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", documento.UsCodigo);
            return View(documento);
        }

        // GET: Documentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documentos == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .Include(d => d.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.DocCodigo == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // POST: Documentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documentos == null)
            {
                return Problem("Entity set 'IntranetProdContext.Documentos'  is null.");
            }
            var documento = await _context.Documentos.FindAsync(id);
            if (documento != null)
            {
                _context.Documentos.Remove(documento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoExists(int id)
        {
          return _context.Documentos.Any(e => e.DocCodigo == id);
        }
    }
}
