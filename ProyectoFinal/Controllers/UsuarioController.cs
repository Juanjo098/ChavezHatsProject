using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Clases.Editar;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        private static int ID_USUARIO;
        public IActionResult Index()
        {
            List<UsuarioCONS> lista = getListaUsuarios();

            if (lista == null) RedirectToAction("Error", "Home");

            getIdTipoUsuario();
            return View(lista);
        }

        [HttpPost]
        public IActionResult Index(int busqueda)
        {
            List<UsuarioCONS> lista = getListaUsuarios();
            getIdTipoUsuario();
            ViewBag.idTipoUsuario = busqueda;

            if (lista == null) return RedirectToAction("Error", "Home");

            if (busqueda == 0) return View(lista);

            lista = lista.FindAll(e => e.idTipoUsuario == busqueda);

            return View(lista);
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            UsuarioCONS usuario = getUsuarioCons(id);
            if (usuario == null) return RedirectToAction("Error", "Index");
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            UsuarioEDIT usuario = getUsuarioEdit(id);
            ID_USUARIO = id;
            if (usuario == null) return RedirectToAction("Error", "Index");
            return View(usuario);
        }

        private void getIdTipoUsuario()
        {
            string error = "";
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<SelectListItem> tipoUsuarios = (
                            from item in db.TiposUsarios
                            where item.Hab == true
                            select new SelectListItem { Text = item.NomTipoUsuario, Value = item.IdTipoUsuario.ToString() }
                        ).ToList();
                    tipoUsuarios.Insert(0, new SelectListItem { Text = "Elige uno", Value = "0" });
                    ViewBag.tipoUsuarios = tipoUsuarios;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private List<UsuarioCONS> getListaUsuarios()
        {
            string error = "";
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<UsuarioCONS> lista = new List<UsuarioCONS>();
                    lista = (
                            from item in db.Usuarios
                            join tipo in db.TiposUsarios
                            on item.IdTipoUsuario equals tipo.IdTipoUsuario
                            where item.Hab == true && tipo.Hab == true
                            select new UsuarioCONS
                            {
                                id = item.IdUsuario,
                                nombre = item.NomUsuario,
                                correo = item.Correo,
                                contrasena = item.Contrasena,
                                tipoUsuario = tipo.NomTipoUsuario,
                                idTipoUsuario = item.IdTipoUsuario
                            }
                        ).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        private UsuarioCONS getUsuarioCons(int id)
        {
            List<UsuarioCONS> lista = getListaUsuarios();
            UsuarioCONS usuario = lista.FirstOrDefault(a => a.id == id);
            if (usuario == null) return null;
            return usuario;
        }

        private UsuarioEDIT getUsuarioEdit(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Usuario u = db.Usuarios.Find(id);

                    if (u == null) return null;

                    return new UsuarioEDIT
                    {
                        nombre = u.NomUsuario,
                        correo = u.Correo,
                        contrasena = u.Contrasena,
                        idTipoUsuario = u.IdTipoUsuario,
                    };

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
