using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Clases.Editar;
using ProyectoFinal.Clases.Insertar;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class ModeloController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<SimpleCONS> lista = new List<SimpleCONS>();
                    lista = (
                            from item in db.Modelos
                            where item.Hab == true
                            select new SimpleCONS { id = item.IdModelo, nombre = item.NomModelo }
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
                            from item in db.Modelos
                            where item.Hab == true
                            select new SimpleCONS { id = item.IdModelo, nombre = item.NomModelo }
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
                    Modelo item = new Modelo { NomModelo = insert.nombre };
                    db.Modelos.Add(item);
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
                    Modelo item = db.Modelos.Find(id);
                    if (item != null)
                    {
                        SimpleCONS cons = new SimpleCONS { id = item.IdModelo, nombre = item.NomModelo };
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
                    Modelo item = db.Modelos.Find(id);
                    if (item != null)
                    {
                        SimpleEDIT cons = new SimpleEDIT { id = item.IdModelo, nombre = item.NomModelo };
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
                    Modelo item = db.Modelos.Find(edit.id);
                    if (item != null)
                    {
                        item.NomModelo = edit.nombre;
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
                    Modelo item = db.Modelos.Find(id);
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
        }
    }

}
