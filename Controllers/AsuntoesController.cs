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
    public class AsuntoesController : Controller
    {
        private readonly IntranetProdContext _context;

        public AsuntoesController(IntranetProdContext context)
        {
            _context = context;
        }

        // GET: Asuntoes
        public async Task<IActionResult> Index()
        {
            var intranetProdContext = _context.Asuntos.Include(a => a.CliCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Asuntoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asuntos == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos
                .Include(a => a.CliCodigoNavigation)
                .FirstOrDefaultAsync(m => m.AsuCodigo == id);
            if (asunto == null)
            {
                return NotFound();
            }

            return View(asunto);
        }

        // GET: Asuntoes/Create
        public IActionResult Create()
        {
            ViewData["AsuResponsable"] = new SelectList((from s in _context.Usuarios
                                                             //where s.UsActivo == "Sí"
                                                             //orderby s.UsApellido1
                                                         select new
                                                         {
                                                             ID = s.UsCodigo,
                                                             FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                         }), "ID", "FullName", null);
            ViewData["CliCodigo"] = new SelectList((from s in _context.Clientes
                                                        //where s.UsActivo == "Sí"
                                                    orderby s.CliNombre
                                                    select new
                                                    {
                                                        ID = s.CliCodigo,
                                                        FullName = s.CliNombre
                                                    }), "ID", "FullName", null);
            return View();
        }

        // POST: Asuntoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsuCodigo,AsuTitulo,AsuIdioma,AsuCategoria,AsuArea,AsuSucursal,AsuResponsable,AsuDescripcion,AsuMoneda,AsuFormaLiquidacion,AsuFeeMonto,AsuFeePeriodicidad,AsuFeeInicio,AsuMontoMaximo,AsuHorasMaximo,AsuDetalleCobranza,AsuEstado,AsuCliente,AsuTarifa,AsuNombreSol,AsuMailSol,AsuDireccionSol,AsuTelefonoSol,AsuCobrable,AsuDescuento,AsuImpuestos,AsuCodigoSecundario,AsuCreador,CliCodigo")] Asunto asunto)
        {
            if (ModelState.IsValid)
            {
                asunto.AsuEstado = "Ingresado";
                asunto.AsuCreador = "";
                _context.Add(asunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsuResponsable"] = new SelectList((from s in _context.Usuarios
                                                             //where s.UsActivo == "Sí"
                                                             //orderby s.UsApellido1
                                                         select new
                                                         {
                                                             ID = s.UsCodigo,
                                                             FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                         }), "ID", "FullName", asunto.AsuResponsable);
            ViewData["CliCodigo"] = new SelectList((from s in _context.Clientes
                                                        //where s.UsActivo == "Sí"
                                                    orderby s.CliNombre
                                                    select new
                                                    {
                                                        ID = s.CliCodigo,
                                                        FullName = s.CliNombre
                                                    }), "ID", "FullName", asunto.CliCodigo);
            return View(asunto);
        }

        // GET: Asuntos/Edit/5
        public async Task<IActionResult> CreateH(int? id)
        {
            if (id == null || _context.Asuntos == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos.FindAsync(id);
            if (asunto == null)
            {
                return NotFound();
            }
            ViewData["Codigo"] = id.ToString();
            ViewData["AsuResponsable"] = new SelectList((from s in _context.Usuarios
                                                             //where s.UsActivo == "Sí"
                                                             //orderby s.UsApellido1
                                                         select new
                                                         {
                                                             ID = s.UsCodigo,
                                                             FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                         }), "ID", "FullName", asunto.AsuResponsable);
            ViewData["CliCodigo"] = new SelectList((from s in _context.Clientes
                                                        //where s.UsActivo == "Sí"
                                                    orderby s.CliNombre
                                                    select new
                                                    {
                                                        ID = s.CliCodigo,
                                                        FullName = s.CliNombre
                                                    }), "ID", "FullName", asunto.CliCodigo);
            return View(asunto);
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateH(int id, [Bind("AsuCodigo,AsuTitulo,AsuIdioma,AsuCategoria,AsuArea,AsuSucursal,AsuResponsable,AsuDescripcion,AsuMoneda,AsuFormaLiquidacion,AsuFeeMonto,AsuFeePeriodicidad,AsuMontoMaximo,AsuHorasMaximo,AsuDetalleCobranza,AsuEstado,AsuCliente,AsuTarifa,AsuNombreSol,AsuMailSol,AsuDireccionSol,AsuTelefonoSol,AsuCobrable,AsuDescuento,AsuImpuestos,AsuCodigoSecundario,AsuCreador,CliCodigo")] Asunto asunto)
        {
            if (id != asunto.AsuCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    asunto.AsuEstado = "Ingresado";
                    asunto.AsuCreador = "";
                    _context.Update(asunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsuntoExists(asunto.AsuCodigo))
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
            ViewData["AsuResponsable"] = new SelectList((from s in _context.Usuarios
                                                             //where s.UsActivo == "Sí"
                                                             //orderby s.UsApellido1
                                                         select new
                                                         {
                                                             ID = s.UsCodigo,
                                                             FullName = s.UsApellido1 + " " + s.UsApellido2 + " " + s.UsNombre1 + " " + s.UsNombre2
                                                         }), "ID", "FullName", asunto.AsuResponsable);
            ViewData["CliCodigo"] = new SelectList((from s in _context.Clientes
                                                        //where s.UsActivo == "Sí"
                                                    orderby s.CliNombre
                                                    select new
                                                    {
                                                        ID = s.CliCodigo,
                                                        FullName = s.CliNombre
                                                    }), "ID", "FullName", asunto.CliCodigo);
            return View(asunto);
        }

        // GET: Asuntoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asuntos == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos.FindAsync(id);
            if (asunto == null)
            {
                return NotFound();
            }
            ViewData["CliCodigo"] = new SelectList(_context.Clientes, "CliCodigo", "CliCodigo", asunto.CliCodigo);
            return View(asunto);
        }

        // POST: Asuntoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsuCodigo,AsuTitulo,AsuIdioma,AsuCategoria,AsuArea,AsuSucursal,AsuResponsable,AsuDescripcion,AsuMoneda,AsuFormaLiquidacion,AsuFeeMonto,AsuFeePeriodicidad,AsuFeeInicio,AsuMontoMaximo,AsuHorasMaximo,AsuDetalleCobranza,AsuEstado,AsuCliente,AsuTarifa,AsuNombreSol,AsuMailSol,AsuDireccionSol,AsuTelefonoSol,AsuCobrable,AsuDescuento,AsuImpuestos,AsuCodigoSecundario,AsuCreador,CliCodigo")] Asunto asunto)
        {
            if (id != asunto.AsuCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsuntoExists(asunto.AsuCodigo))
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
            ViewData["CliCodigo"] = new SelectList(_context.Clientes, "CliCodigo", "CliCodigo", asunto.CliCodigo);
            return View(asunto);
        }

        // GET: Asuntoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asuntos == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos
                .Include(a => a.CliCodigoNavigation)
                .FirstOrDefaultAsync(m => m.AsuCodigo == id);
            if (asunto == null)
            {
                return NotFound();
            }

            return View(asunto);
        }

        // POST: Asuntoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asuntos == null)
            {
                return Problem("Entity set 'IntranetProdContext.Asuntos'  is null.");
            }
            var asunto = await _context.Asuntos.FindAsync(id);
            if (asunto != null)
            {
                _context.Asuntos.Remove(asunto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsuntoExists(int id)
        {
          return (_context.Asuntos?.Any(e => e.AsuCodigo == id)).GetValueOrDefault();
        }

        [HttpGet]
        public JsonResult GetSolicitante(int id)
        {
            var clientes = _context.Clientes.Where(a => a.CliCodigo == id).FirstOrDefault();
            return Json(clientes, new System.Text.Json.JsonSerializerOptions());
        }

        [HttpGet]
        public JsonResult GetContacto(int id)
        {
            var contacto = _context.ContactoFacturacions.Where(a => a.CofCodigo == id).FirstOrDefault();
            return Json(contacto, new System.Text.Json.JsonSerializerOptions());
        }

        [HttpGet]
        public JsonResult Contacto(int IdCliente)
        {
            List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();
            using (var context = _context)
            {
                lst = ((List<ElementJsonIntKey>)(from d in context.ContactoFacturacions
                                                 where d.CliCodigo.Equals(IdCliente)
                                                 select new ElementJsonIntKey
                                                 {
                                                     Value = d.CofCodigo,
                                                     Text = d.CofNombre + "-" + d.CofMail
                                                 }).ToList());
            }
            return Json(lst, new System.Text.Json.JsonSerializerOptions());
        }


        public class ElementJsonIntKey
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        #region
        public ActionResult GetHitos(int id)
        {

            using (var dc = _context)
            {
                var data = dc.Hitos.Where(a => a.AsuCodigo == id).OrderBy(a => a.HiFecha).ToList();
                return Json(data, new System.Text.Json.JsonSerializerOptions());
            }
        }

        [HttpPost]
        public async Task<JsonResult> CreateHitoAsync(Hito hi)
        {
            if (ModelState.IsValid)
            {
                Hito hitos = new Hito();
                hitos.HiFecha = hi.HiFecha;
                hitos.HiDescripcion = hi.HiDescripcion;
                hitos.HiValor = hi.HiValor;
                hitos.HiObservacion = hi.HiObservacion;
                hitos.AsuCodigo = hi.AsuCodigo;
                _context.Add(hi);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Hito creado con éxito" }, new System.Text.Json.JsonSerializerOptions());
            }
            return Json(new { error = true, message = "Houston tenemos un problema!" }, new System.Text.Json.JsonSerializerOptions());
        }

        [HttpPost]
        public ActionResult DeleteHito(int id)
        {
            using (var dc = _context)
            {
                Hito hitos = dc.Hitos.Where(x => x.HiCodigo == id).FirstOrDefault<Hito>();
                dc.Hitos.Remove(hitos);
                dc.SaveChanges();
                return Json(new { success = true, message = "Hito eliminado con éxito" }, new System.Text.Json.JsonSerializerOptions());
            }

        }
        #endregion

    }
}
