using INTRANET_CR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System.Diagnostics;
using System.Security.Claims;

namespace INTRANET_CR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GraphServiceClient _graphServiceClient;
        private readonly IntranetProdContext _context;

        public HomeController(ILogger<HomeController> logger, IntranetProdContext context, IConfiguration configuration,
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

        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> IndexAsync()
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
            try
            {
                var idaspnet = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Usuario usuarios = _context.Usuarios.Where(x => x.UsId == idaspnet).FirstOrDefault();
                if (usuarios == null)
                {                  

                    return RedirectToAction("Registro", "Usuarios");
                    //ViewBag.Message = "Su acceso esta restringido, comuníquese con el administrador de la plataforma. ";

                }
                else if (usuarios != null)
                {
                    Informacion informacion = _context.Informacions.Where(x => x.UsCodigo == usuarios.UsCodigo).FirstOrDefault();
                    if (informacion == null)
                    {
                        return RedirectToAction("Registro", "Informacions");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Registro", "Usuarios");
            }            
            return View(ViewData["Photo"]);
        }

        public IActionResult Privacy()
        {            
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}