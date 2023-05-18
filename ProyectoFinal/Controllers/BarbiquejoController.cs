using ProyectoFinal.Clases.Consultas;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Clases.Editar;
using Microsoft.AspNetCore.Mvc.Abstractions;
using ProyectoFinal.Clases.Insertar;

namespace ProyectoFinal.Controllers
{
    public class BarbiquejoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<SimpleCONS> lista = new List<SimpleCONS>();
                    lista = (
                            from item in db.Barbiquejos
                            where item.Hab == true
                            select new SimpleCONS { id = item.IdBarbiquejo, nombre = item.NomBarbiquejo }
                        ).ToList();
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Index(string busqueda)
        {
            try
            {
                ViewBag.busqueda = busqueda;
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<SimpleCONS> list = new List<SimpleCONS>();
                    list = (
                            from item in db.Barbiquejos
                            where item.Hab == true
                            select new SimpleCONS { id = item.IdBarbiquejo, nombre = item.NomBarbiquejo }
                        ).ToList();
                    if (String.IsNullOrEmpty(busqueda))
                    {
                        return View(list);
                    }
                    list = list.FindAll(item => item.nombre.ToUpper().Contains(busqueda.ToUpper()));
                    return View(list);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(SimpleINST insert)
        {
            if (!ModelState.IsValid)
            {
                return View(insert);
            }
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Barbiquejo bar = new Barbiquejo {NomBarbiquejo = insert.nombre };
                    db.Barbiquejos.Add(bar);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Barbiquejo item = db.Barbiquejos.Find(id);
                    if (item != null)
                    {
                        SimpleCONS cons = new SimpleCONS { id = item.IdBarbiquejo, nombre = item.NomBarbiquejo };
                        return View(cons);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Barbiquejo item = db.Barbiquejos.Find(id);
                    if (item != null)
                    {
                        SimpleEDIT cons = new SimpleEDIT { id = item.IdBarbiquejo, nombre = item.NomBarbiquejo };
                        return View(cons);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Editar(SimpleEDIT edit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Editar", new { id = edit.id });
                }
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Barbiquejo item = db.Barbiquejos.Find(edit.id);
                    if (item != null)
                    {
                        item.NomBarbiquejo = edit.nombre;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Barbiquejo item = db.Barbiquejos.Find(id);
                    if (item != null)
                    {
                        item.Hab = false;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
