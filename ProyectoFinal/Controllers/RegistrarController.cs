using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Insertar;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class RegistrarController : Controller
    {
        private static int ID_CLIENTE = 2;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UsuarioINST item)
        {
            if (!ModelState.IsValid) return View(item);

            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    if (db.Usuarios.FirstOrDefault(e => e.Correo == item.correo) != null) {
                        ViewBag.error = "El correo: " + item.correo + " ya fue registrado, intente con otro.";
                        return View("Index");
                    } 
                    Usuario u = new Usuario
                    {
                        NomUsuario = item.nombre,
                        Correo = item.correo.ToLower(),
                        Contrasena = item.contrasena,
                        IdTipoUsuario= ID_CLIENTE
                    };
                    db.Usuarios.Add(u);
                    db.SaveChanges();

                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
