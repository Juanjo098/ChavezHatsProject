using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            FillTipoUsuarioDropdown();
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
							select new UsuarioCONS { 
								id = item.IdUsuario,
								nombre = item.NomUsuario,
								correo = item.Correo,
								contrasena = item.Contrasena,
								tipoUsuario = tipo.NomTipoUsuario,
                                idTipoUsuario = item.IdTipoUsuario
							}
						).ToList();
					return View(lista);
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", "Index");
			}
        }

		[HttpPost]
        public IActionResult Index(int busqueda)
        {
            FillTipoUsuarioDropdown();
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
                    if (busqueda == 0) return View(lista);

                    ViewBag.usuario = busqueda;

                    lista = lista.FindAll(e => e.idTipoUsuario == busqueda);
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Index");
            }
        }

        private void FillTipoUsuarioDropdown()
        {
            using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
            {
                List<SelectListItem> lista = new List<SelectListItem>();
                lista = (
                        from item in db.TiposUsarios
                        where item.Hab == true
                        select new SelectListItem {
                            Value = item.IdTipoUsuario.ToString(),
                            Text = item.NomTipoUsuario }
                    ).ToList();
                lista.Insert(0, new SelectListItem { Value="0", Text="Elija uno" });
                ViewBag.usuarios = lista;
            }
        }
    }
}
