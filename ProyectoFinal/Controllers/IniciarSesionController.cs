using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class IniciarSesionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IniciarSesionCONS item)
        {
            if (!ModelState.IsValid) return View(item);

            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    if (db.Usuarios.FirstOrDefault(e =>
                        e.Correo == item.correo &&
                        e.Contrasena == item.contrasena) == null)
                    {
                        ViewBag.error = "error";
                        return View(item);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
