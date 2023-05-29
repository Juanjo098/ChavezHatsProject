using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Clases.Consultas;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoFinal.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            FillClasesDropdown();
            FillModelosDropdown();
            FillTallasDropdown();
			try
			{
				using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
				{
					List<ProductoCONS> lista = (
							from som in db.Sombreros
							join mod in db.Modelos
							on som.IdModelo equals mod.IdModelo
							join clase in db.Clases
							on som.IdClase equals clase.IdClase
                            join talla in db.TamanoTallas
                            on som.IdTamTalla equals talla.IdTamTalla
							where som.Hab == true
							select new ProductoCONS
							{
								id = som.IdSombrero,
								modelo = mod.NomModelo,
								clase = clase.NomClase,
								strock = (int)som.Stock,
								precio = (float)som.Precio,
								imagen = som.Imagen,
                                talla = talla.TamTalla,
								idClase = clase.IdClase,
								idModelo = mod.IdModelo,
                                idTalla = som.IdTamTalla,
							}
						).ToList();
					return View(lista);
				}
			}
			catch (Exception ex)
			{
                return RedirectToAction("Error","Home");
			}
        }

        [HttpPost]
        public IActionResult Index(ProductoCONS item)
        {
            FillClasesDropdown();
            FillModelosDropdown();
            FillTallasDropdown();
            ViewBag.clase = item.idClase;
            ViewBag.modelo = item.idModelo;
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<ProductoCONS> lista = (
                            from som in db.Sombreros
                            join mod in db.Modelos
                            on som.IdModelo equals mod.IdModelo
                            join clase in db.Clases
                            on som.IdClase equals clase.IdClase
                            join talla in db.TamanoTallas
                            on som.IdTamTalla equals talla.IdTamTalla
                            where som.Hab == true
                            select new ProductoCONS
                            {
                                id = som.IdSombrero,
                                modelo = mod.NomModelo,
                                clase = clase.NomClase,
                                strock = (int)som.Stock,
                                precio = (float)som.Precio,
                                imagen = som.Imagen,
                                idClase = som.IdClase,
                                idModelo = som.IdModelo,
                                idTalla = som.IdTamTalla,
                                talla = talla.TamTalla,
                            }
                        ).ToList();
                    lista = lista.FindAll(e => e.Comparar(item));
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
		public IActionResult Detalles(int id)
		{
			try
			{
				using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
				{
                    List<SombreroCONSD> lista = (
                            from item in db.Sombreros
                            join tam in db.TamanoTallas
                            on item.IdTamTalla equals tam.IdTamTalla
                            join talla in db.Tallas
                            on tam.IdTalla equals talla.IdTalla
                            join modelo in db.Modelos
                            on item.IdModelo equals modelo.IdModelo
                            join clase in db.Clases
                            on item.IdClase equals clase.IdClase
                            join material in db.Materials
                            on item.IdMaterial equals material.IdMaterial
                            join toquilla in db.Toquillas
                            on material.IdToquilla equals toquilla.IdToquilla
                            join forro in db.Forros
                            on material.IdForro equals forro.IdForro
                            join barbiquejo in db.Barbiquejos
                            on material.IdBarbiquejo equals barbiquejo.IdBarbiquejo
                            join tafiretes in db.Tafiletes
                            on material.IdTafiletes equals tafiretes.IdTafiletes
                            where item.Hab == true
                            select new SombreroCONSD
                            {
                                id = item.IdSombrero,
                                nomModelo = modelo.NomModelo,
                                nomClase = clase.NomClase,
                                toquilla = toquilla.NomToquilla,
                                forro = forro.NomForro,
                                barbiquejo = barbiquejo.NomBarbiquejo,
                                tafiretes = tafiretes.NomTafiletes,
                                ojitos = material.Ojillos ? "Sí" : "No",
                                resorte = material.Resorte ? "Sí" : "No",
                                nomTalla = talla.NomTalla,
                                tamTalla = tam.TamTalla,
                                medFalda = (float)item.MedFalda,
                                precio = (float)item.Precio,
                                stock = (int)item.Stock,
                                personalizado = (bool)item.Personalizado ? "Sí" : "No",
                                imagen = item.Imagen,
                                idModelo = item.IdModelo,
                                idClase = item.IdClase,
                                idTamTalla = item.IdTamTalla,
                            }
                        ).ToList();

                    SombreroCONSD som = lista.Find(e => e.id == id);
                    if (som == null) return RedirectToAction("Error", "Home");

                    return View(som);
                }
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error", "Home");
			}
		}

        private void FillModelosDropdown()
        {
            using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
            {
                List<SelectListItem> lista = (
                        from item in db.Modelos
                        where item.Hab == true
                        select new SelectListItem {
                            Value = item.IdModelo.ToString(),
                            Text = item.NomModelo
                        }
                    ).ToList();
                lista.Insert(0, new SelectListItem { Value = "0", Text = "Elija uno" });
                ViewBag.modelos = lista;
            }
        }

        private void FillClasesDropdown()
        {
            using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
            {
                List<SelectListItem> lista = (
                        from item in db.Clases
                        where item.Hab == true
                        select new SelectListItem
                        {
                            Value = item.IdClase.ToString(),
                            Text = item.NomClase
                        }
                    ).ToList();
                lista.Insert(0, new SelectListItem { Value = "0", Text = "Elija uno" });
                ViewBag.clases = lista;
            }
        }

        private void FillTallasDropdown()
        {
            using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
            {
                List<SelectListItem> lista = (
                        from item in db.TamanoTallas
                        where item.Hab == true
                        select new SelectListItem
                        {
                            Value = item.IdTamTalla.ToString(),
                            Text = item.TamTalla.ToString()
                        }
                    ).ToList();
                lista.Insert(0, new SelectListItem { Value = "0", Text = "Elija uno" });
                ViewBag.tallas = lista;
            }
        }
    }
}
