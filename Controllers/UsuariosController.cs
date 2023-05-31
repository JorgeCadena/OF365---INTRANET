using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INTRANET_CR.Models;
using System.Security.Claims;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace INTRANET_CR.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly GraphServiceClient _graphServiceClient;
        private readonly IntranetProdContext _context;

        public UsuariosController(ILogger<UsuariosController> logger, IntranetProdContext context, IConfiguration configuration,
                     GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _context = context;
            _graphServiceClient = graphServiceClient;
        }

        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Profile()
        {
            var me = await _graphServiceClient.Me.Request().GetAsync();
            ViewData["Me"] = me;

            try
            {
                // Get user photo
                using (var photoStream = await _graphServiceClient.Me.Photo.Content.Request().GetAsync())
                {
                    byte[] photoByte = ((MemoryStream)photoStream).ToArray();
                    ViewData["Photo"] = Convert.ToBase64String(photoByte);
                }
            }
            catch (System.Exception)
            {
                ViewData["Photo"] = null;
            }

            return View(ViewData["Photo"]);
        }
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var idaspnet = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario usuarios = _context.Usuarios.Where(x => x.UsId == idaspnet).FirstOrDefault();
            if (usuarios == null)
            {

                return RedirectToAction("Registro", "Usuarios");
                //ViewBag.Message = "Su acceso esta restringido, comuníquese con el administrador de la plataforma. ";

            }
            var intranetProdContext = _context.Usuarios.Include(u => u.EmCodigoNavigation);
            return View(await intranetProdContext.ToListAsync());
        }

        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        // GET: Usuarios
        public async Task<IActionResult> IndexUser()
        {
            var me = await _graphServiceClient.Me.Request().GetAsync();
            ViewData["Me"] = me;
            try
            {
                // Get user photo
                using (var photoStream = await _graphServiceClient.Me.Photo.Content.Request().GetAsync())
                {
                    byte[] photoByte = ((MemoryStream)photoStream).ToArray();
                    ViewData["Photo"] = Convert.ToBase64String(photoByte);
                }
            }
            catch (System.Exception)
            {
                ViewData["Photo"] = null;
            }
            var idaspnet = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario usuarios = _context.Usuarios.Where(x => x.UsId == idaspnet).FirstOrDefault();
            if (usuarios == null)
            {
                return RedirectToAction("Registro", "Usuarios");
                //ViewBag.Message = "Su acceso esta restringido, comuníquese con el administrador de la plataforma. ";

            }
            var intranetProdContext = _context.Usuarios.Where(u => u.UsId == usuarios.UsId);
            return View(await intranetProdContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.UsCodigo == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsCodigo,UsNombre1,UsNombre2,UsNombre3,UsApellido1,UsApellido2,UsEstado,UsActivo,UsJefe,UsGerencia,UsCambio,UsTerminos,UsId,UsRol,UsAdicional,UsCorreo,EmCodigo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.UsCorreo = User.FindFirstValue(ClaimTypes.Name);
                usuario.UsId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmNombre", usuario.EmCodigo);
            return View(usuario);
        }


        // GET: Usuarios/Create
        public IActionResult Registro()
        {
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmNombre");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("UsCodigo,UsNombre1,UsNombre2,UsNombre3,UsApellido1,UsApellido2,UsEstado,UsActivo,UsJefe,UsGerencia,UsCambio,UsTerminos,UsId,UsRol,UsAdicional,UsCorreo,EmCodigo")] Usuario usuario)
        {           

            if (ModelState.IsValid)
            {
                usuario.UsNombre3 = "";
                usuario.UsEstado = "Inactivo";
                usuario.UsActivo = "";
                usuario.UsJefe = "";
                usuario.UsGerencia = "";
                usuario.UsCambio = "";
                usuario.UsRol = "Usuario";
                //usuario.UsTerminos = "Sí";
                //usuario.EmCodigo = 1;
                usuario.UsId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                usuario.UsCorreo = User.Identity.Name;
                //usuario.UsAdicional = User.FindFirst("preferred_username")?.Value;


                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Registro", "Informacions");
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmNombre", usuario.EmCodigo);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", usuario.EmCodigo);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsCodigo,UsNombre1,UsNombre2,UsNombre3,UsApellido1,UsApellido2,UsEstado,UsActivo,UsJefe,UsGerencia,UsCambio,UsTerminos,UsId,UsRol,UsAdicional,UsCorreo,EmCodigo")] Usuario usuario)
        {
            if (id != usuario.UsCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsCodigo))
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
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmCodigo", usuario.EmCodigo);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> EditUser()
        {
            var idaspnet = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario usuarios = _context.Usuarios.Where(x => x.UsId == idaspnet).FirstOrDefault();
            var id = usuarios.UsCodigo;
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmNombre", usuario.EmCodigo);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, [Bind("UsCodigo,UsNombre1,UsNombre2,UsNombre3,UsApellido1,UsApellido2,UsEstado,UsActivo,UsJefe,UsGerencia,UsCambio,UsTerminos,UsId,UsRol,UsAdicional,UsCorreo,EmCodigo")] Usuario usuario)
        {
            if (id != usuario.UsCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsCodigo))
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
            ViewData["EmCodigo"] = new SelectList(_context.Empresas, "EmCodigo", "EmNombre", usuario.EmCodigo);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Aceptacion(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            if (usuario.UsEstado == "Activo")
            {
                return RedirectToAction("Index", "Home");
            }
            var informacion = _context.Informacions.Where(x => x.UsCodigo == id).FirstOrDefault();
            var empresa = await _context.Empresas.FindAsync(usuario.EmCodigo);
            ViewData["Empresa"] = empresa.EmNombre;
            ViewData["Cedula"] = informacion.InfIdentificacion;
            ViewData["Usuario"] = usuario.UsNombre1 + " " + usuario.UsNombre2 + " " + usuario.UsApellido1 + " " + usuario.UsApellido2;
            ViewData["UsCodigo"] = id;

            DateTime thisDay = DateTime.Today;
            ViewData["Ano"] = thisDay.ToString("yyyy");
            ViewData["Mes"] = thisDay.ToString("MMMM");
            ViewData["Dia"] = thisDay.ToString("dd");
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aceptacion(int id)
        {
            var tabla = _context.Usuarios.Find(id);
            if (tabla.UsEstado == "Activo")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                tabla.UsEstado = "Activo";
                _context.Update(tabla);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }                             
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.EmCodigoNavigation)
                .FirstOrDefaultAsync(m => m.UsCodigo == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'IntranetProdContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.UsCodigo == id)).GetValueOrDefault();
        }
    }
}
