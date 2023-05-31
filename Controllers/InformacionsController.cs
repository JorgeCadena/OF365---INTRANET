using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTRANET_CR.Models;
using System.Security.Claims;
using System.Net;

namespace INTRANET_CR.Controllers
{
    public class InformacionsController : Controller
    {
        private readonly IntranetProdContext _context;

        public InformacionsController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Informacions
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Informacions.Include(i => i.UsCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Informacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Informacions == null)
            {
                return NotFound();
            }

            var informacion = await _context.Informacions
                .Include(i => i.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.InfCodigo == id);
            if (informacion == null)
            {
                return NotFound();
            }

            return View(informacion);
        }

        // GET: Informacions/Create
        public IActionResult Create()
        {
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1");
            return View();
        }

        // POST: Informacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InfCodigo,InfOrigen,InfGenero,InfIdentificacion,InfEtnia,InfSangre,InfProvincia,InfCiudad,InfDireccion,InfTelefono,InfMail,InfEstadoCivil,InfLugarNacimiento,InfFechaNacimiento,InfDiscapacidad,InfPorcentajeDiscapacidad,InfNombreContacto,InfTelefonoContacto,InfRelacion,InfObservaciones,InfMigranteRetornado,InfEstado,InfFoto,InfNombreFoto,UsCodigo")] Informacion informacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", informacion.UsCodigo);
            return View(informacion);
        }


        // GET: Informacions/Create
        public IActionResult Registro()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.Usuarios.Where(x => x.UsId == id).FirstOrDefault();
            //ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", user);
            ViewData["UsCodigo"] = user.UsCodigo;
            return View();
        }

        // POST: Informacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("InfCodigo,InfOrigen,InfGenero,InfIdentificacion,InfEtnia,InfSangre,InfProvincia,InfCiudad,InfDireccion,InfTelefono,InfMail,InfEstadoCivil,InfLugarNacimiento,InfFechaNacimiento,InfDiscapacidad,InfPorcentajeDiscapacidad,InfNombreContacto,InfTelefonoContacto,InfRelacion,InfObservaciones,InfMigranteRetornado,InfEstado,InfFoto,InfNombreFoto,UsCodigo")] Informacion informacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Aceptacion", "Usuarios", new {id = informacion.UsCodigo});
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", informacion.UsCodigo);
            return View(informacion);
        }

        // GET: Informacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Informacions == null)
            {
                return NotFound();
            }

            var informacion = await _context.Informacions.FindAsync(id);
            if (informacion == null)
            {
                return NotFound();
            }
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", informacion.UsCodigo);
            return View(informacion);
        }

        // POST: Informacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InfCodigo,InfOrigen,InfGenero,InfIdentificacion,InfEtnia,InfSangre,InfProvincia,InfCiudad,InfDireccion,InfTelefono,InfMail,InfEstadoCivil,InfLugarNacimiento,InfFechaNacimiento,InfDiscapacidad,InfPorcentajeDiscapacidad,InfNombreContacto,InfTelefonoContacto,InfRelacion,InfObservaciones,InfMigranteRetornado,InfEstado,InfFoto,InfNombreFoto,UsCodigo")] Informacion informacion)
        {
            if (id != informacion.InfCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformacionExists(informacion.InfCodigo))
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
            ViewData["UsCodigo"] = new SelectList(_context.Usuarios, "UsCodigo", "UsApellido1", informacion.UsCodigo);
            return View(informacion);
        }

        // GET: Informacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Informacions == null)
            {
                return NotFound();
            }

            var informacion = await _context.Informacions
                .Include(i => i.UsCodigoNavigation)
                .FirstOrDefaultAsync(m => m.InfCodigo == id);
            if (informacion == null)
            {
                return NotFound();
            }

            return View(informacion);
        }

        // POST: Informacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informacions == null)
            {
                return Problem("Entity set 'IntranetProdContext.Informacions'  is null.");
            }
            var informacion = await _context.Informacions.FindAsync(id);
            if (informacion != null)
            {
                _context.Informacions.Remove(informacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformacionExists(int id)
        {
          return _context.Informacions.Any(e => e.InfCodigo == id);
        }
    }
}
