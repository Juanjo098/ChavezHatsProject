using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
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

                    lista = lista.FindAll(e => e.idTipoUsuario == busqueda);
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Index");
            }
        }
    }
}
