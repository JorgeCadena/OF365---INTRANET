using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTRANET_CR.Models;
using Microsoft.Identity.Web;

namespace INTRANET_CR.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IntranetProdContext _context;

        public ClientesController(IntranetProdContext context)
        {
            _context = context;
        }

        public ActionResult GetUserName(string id)
        {
            try
            {
                var usuario = _context.Usuarios.Where(x => x.UsId == id).FirstOrDefault();
                if (usuario == null)
                {
                    return NotFound();
                }
                var username = usuario.UsApellido1 + " " + usuario.UsApellido2 + " " + usuario.UsNombre1 + " " + usuario.UsNombre2;
                return Content(username);
            }
            catch (Exception)
            {
                return Content("UserName");
            }
        }
        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var iNT_PROD_CRContext = _context.Clientes.Include(c => c.EmCodigoNavigation);
            return View(await iNT_PROD_CRContext.ToListAsync());
        }

        // GET: Clientes
        public async Task<IActionResult> IndexUser()
        {

            var iNT_PROD_CRContext = _context.Clientes.Include(c => c.EmCodigoNavigation);
            return View(await iNT_PROD_CRContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CliCodigo == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        // GET: Clientes/Create
        public IActionResult Create()
        {

            ViewData["CliEncargado"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", null);
            ViewData["CliComercial"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", null);

            ViewData["CliPais"] = new SelectList(_context.Paises, "PaNombre", "PaNombre");
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CliCodigo,CliNombre,CliRazonSocial,CliTipoIdentificacion,CliIdentificacion,CliEncargado,CliComercial,CliImpuestos,CliDireccion,CliPostal,CliPais,CliCiudad,CliTelefono,CliSolicitante,CliTelefonoSol,CliMailSol,CliDireccionSol,CliTarifa,CliDescuento,CliEstado,CliFecha,EmCodigo")] Cliente cliente)
        {
            cliente.EmCodigo = 1;
            //cliente.CliFecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CliEncargado"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", null);
            ViewData["CliComercial"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", null);

            ViewData["CliPais"] = new SelectList(_context.Paises, "PaNombre", "PaNombre");
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", cliente.EmCodigo);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CliEncargado"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", cliente.CliEncargado);
            ViewData["CliComercial"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", cliente.CliComercial);

            ViewData["CliPais"] = new SelectList(_context.Paises, "PaNombre", "PaNombre", cliente.CliPais);
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", cliente.EmCodigo);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CliCodigo,CliNombre,CliRazonSocial,CliTipoIdentificacion,CliIdentificacion,CliEncargado,CliComercial,CliImpuestos,CliDireccion,CliPostal,CliPais,CliCiudad,CliTelefono,CliSolicitante,CliTelefonoSol,CliMailSol,CliDireccionSol,CliTarifa,CliDescuento,CliEstado,CliFecha,EmCodigo")] Cliente cliente)
        {
            if (id != cliente.CliCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.CliCodigo))
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
            ViewData["CliEncargado"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", cliente.CliEncargado);
            ViewData["CliComercial"] = new SelectList((from s in _context.Usuarios
                                                           //where s.UsActivo == "Sí"
                                                           //orderby s.UsApellido1
                                                       select new
                                                       {
                                                           ID = s.UsCodigo,
                                                           FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                       }), "ID", "FullName", cliente.CliComercial);

            ViewData["CliPais"] = new SelectList(_context.Paises, "PaNombre", "PaNombre", cliente.CliPais);
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", cliente.EmCodigo);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.CliCodigo == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'INT_PROD_CRContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.CliCodigo == id);
        }
    }
}
