using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProyectoFinal.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            List<VentaCONS> lista = getListaVenta();

            if (lista == null) return RedirectToAction("Error", "Home");

            return View(lista);
        }

        [HttpPost]
        public IActionResult Index(DateTime fechaInicio, DateTime fechaFinal) {
            if (fechaInicio == DateTime.MinValue || fechaFinal == DateTime.MinValue) return View();
            if (DateTime.Compare(fechaInicio, fechaFinal) > 0 || DateTime.Compare(fechaInicio, fechaFinal) == 0) return View();

            ViewBag.fechaInicio = fechaInicio;
            ViewBag.fechaFinal = fechaFinal;

            List<VentaCONS> lista = getListaVenta();

            if (lista == null) return RedirectToAction("Error", "Home");

            lista = lista.FindAll(e => DateTime.Compare(e.dateTime, fechaInicio) > 0 &&
                DateTime.Compare(e.dateTime, fechaFinal) < 0);

            return View(lista);
        }

        private List<VentaCONS> getListaVenta()
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<VentaCONS> lista = (
                            from item in db.Venta
                            where item.Hab == true
                            select new VentaCONS
                            {
                                id = item.IdVenta,
                                fecha = item.FchVenta.ToString(),
                                total = (float)item.TotalVenta,
                                dateTime = (DateTime)item.FchVenta
                            }
                        ).ToList();
                    return (lista);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
