using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Clases.Consultas;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Clases.Insertar;
using ProyectoFinal.Clases.Editar;
using System;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.CodeAnalysis.Differencing;

namespace ProyectoFinal.Controllers
{
    public class MaterialController : Controller
    {
        private static int s_IdBuscado;

        public IActionResult Index()
        {
            List<MaterialCONS> lista = getMaterialsList();

            if (lista == null)
                return RedirectToAction("Error", "Index");

            return View(lista);
        }

        public IActionResult Insertar()
        {
            fillToquillaDropdown(false);
            fillForroDropdown(false);
            fillBarbiquejoDropdown(false);
            fillTafiretesDropdown(false);
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(MaterialINST item)
        {
            if (!ModelState.IsValid)
            {
                fillToquillaDropdown(false);
                fillForroDropdown(false);
                fillBarbiquejoDropdown(false);
                fillTafiretesDropdown(false);
                ViewBag.toquilla = item.idToquilla;
                ViewBag.forro = item.idForro;
                ViewBag.barbiquejo = item.idBarbiquejo;
                ViewBag.tafirete = item.idTafirete;
                ViewBag.ojillos = item.ojillos;
                ViewBag.resorte = item.resorte;
                return View();
            }
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    if (YaExiste(db, item.idToquilla, item.idForro, item.idBarbiquejo, item.idTafirete, item.ojillos, item.resorte))
                    {
                        ViewBag.toquilla = item.idToquilla;
                        ViewBag.forro = item.idForro;
                        ViewBag.barbiquejo = item.idBarbiquejo;
                        ViewBag.tafirete = item.idTafirete;
                        ViewBag.ojillos = item.ojillos;
                        ViewBag.resorte = item.resorte;
                        ViewBag.error = "error";
                        fillToquillaDropdown(false);
                        fillForroDropdown(false);
                        fillBarbiquejoDropdown(false);
                        fillTafiretesDropdown(false);
                        return View();
                    }

                    db.Materials.Add(new Material
                    {
                        IdToquilla = item.idToquilla,
                        IdForro = item.idForro,
                        IdBarbiquejo = item.idBarbiquejo,
                        IdTafiletes = item.idTafirete,
                        Ojillos = item.ojillos,
                        Resorte = item.resorte
                    });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Index");
            }
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            MaterialCONS mat = getMaterial(id);

            if (mat == null) return RedirectToAction("Error", "Home");

            return View(mat);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            fillToquillaDropdown(true);
            fillForroDropdown(true);
            fillBarbiquejoDropdown(true);
            fillTafiretesDropdown(true);

            s_IdBuscado = id;

            MaterialCONS mat = getMaterial(id);

            if (mat == null) return RedirectToAction("Error", "Home");

            return View(new MaterialEDIT
            {
                id = mat.id,
                idToquilla = mat.idToquilla,
                idForro = mat.idForro,
                idBarbiquejo = mat.idBarbiquejo,
                idTafirete = mat.idTafiretes,
                ojillos = mat.ojitos == "Sí" ? true : false,
                resorte = mat.resorte == "Sí" ? true : false,
            });
        }

        [HttpPost]
        public IActionResult Editar(MaterialEDIT item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Editar", new { id = s_IdBuscado });
                }
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    if (YaExiste(db,item.idToquilla, item.idForro, item.idBarbiquejo, item.idTafirete, item.ojillos, item.resorte))
                    {
                        TempData["toquilla"] = item.idToquilla;
                        TempData["forro"] = item.idForro;
                        TempData["barbiquejo"] = item.idBarbiquejo;
                        TempData["tafirete"] = item.idTafirete;
                        TempData["ojillos"] = item.ojillos;
                        TempData["resorte"] = item.resorte;
                        TempData["error"] = "error";
                        fillToquillaDropdown(true);
                        fillForroDropdown(true);
                        fillBarbiquejoDropdown(true);
                        fillTafiretesDropdown(true);
                        return RedirectToAction("Editar", new { id = s_IdBuscado });
                    }
                    Material mat = db.Materials.Find(s_IdBuscado);

                    if (mat == null) return RedirectToAction("Error", "Home");

                    mat.IdToquilla = item.idToquilla;
                    mat.IdForro = item.idForro;
                    mat.IdBarbiquejo = item.idBarbiquejo;
                    mat.IdTafiletes = item.idTafirete;
                    mat.Ojillos = item.ojillos;
                    mat.Resorte = item.resorte;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Material mat = db.Materials.Find(id);

                    if (mat == null) 
                        return RedirectToAction("Error", "Home");

                    mat.Hab = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private List<MaterialCONS> getMaterialsList()
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<MaterialCONS> lista = new List<MaterialCONS>();

                    lista = (
                            from item in db.Materials
                            join barbiquejo in db.Barbiquejos
                            on item.IdBarbiquejo equals barbiquejo.IdBarbiquejo
                            join toquilla in db.Toquillas
                            on item.IdToquilla equals toquilla.IdToquilla
                            join tafirete in db.Tafiletes
                            on item.IdTafiletes equals tafirete.IdTafiletes
                            join forro in db.Forros
                            on item.IdForro equals forro.IdForro
                            where item.Hab == true
                            select new MaterialCONS
                            {
                                id = item.IdMaterial,
                                idToquilla = item.IdToquilla,
                                idForro = item.IdForro,
                                idBarbiquejo = item.IdBarbiquejo,
                                idTafiretes = item.IdTafiletes,
                                toquilla = toquilla.NomToquilla,
                                forro = forro.NomForro,
                                barbiquejo = barbiquejo.NomBarbiquejo,
                                tafiretes = tafirete.NomTafiletes,
                                ojitos = item.Ojillos ? "Sí" : "No",
                                resorte = item.Resorte ? "Sí" : "No",
                            }
                        ).ToList();

                    return lista;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private MaterialCONS getMaterial(int id)
        {
            List<MaterialCONS> lista = getMaterialsList();
            return lista.Find(e => e.id == id);
        }

        private bool YaExiste(CHAVEZ_HATSContext db, int idToquilla, int idForro, int idBarbiquejo, int idTafirete, bool ojillos, bool resorte)
        {
            Material mat = db.Materials.FirstOrDefault(
                m => m.IdToquilla == idToquilla &&
                m.IdForro == idForro &&
                m.IdBarbiquejo == idBarbiquejo &&
                m.IdTafiletes == idTafirete &&
                m.Ojillos == ojillos &&
                m.Resorte == resorte
             );
            return mat != null;
        }
    

    private void fillToquillaDropdown(bool edit)
    {
        using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista = (
                    from item in db.Toquillas
                    where item.Hab == true
                    select new SelectListItem
                    {
                        Text = item.NomToquilla,
                        Value = item.IdToquilla.ToString()
                    }
                ).ToList();
            if (!edit) lista.Insert(0, new SelectListItem { Text = "Elige uno", Value = "0" });
            ViewBag.toquillas = lista;
        }
    }

    private void fillForroDropdown(bool edit)
    {
        using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista = (
                    from item in db.Forros
                    where item.Hab == true
                    select new SelectListItem
                    {
                        Text = item.NomForro,
                        Value = item.IdForro.ToString()
                    }
                ).ToList();
            if (!edit) lista.Insert(0, new SelectListItem { Text = "Elige uno", Value = "0" });
            ViewBag.forros = lista;
        }
    }

    private void fillBarbiquejoDropdown(bool edit)
    {
        using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista = (
                    from item in db.Barbiquejos
                    where item.Hab == true
                    select new SelectListItem
                    {
                        Text = item.NomBarbiquejo,
                        Value = item.IdBarbiquejo.ToString()
                    }
                ).ToList();
            if (!edit) lista.Insert(0, new SelectListItem { Text = "Elige uno", Value = "0" });
            ViewBag.barbiquejos = lista;
        }
    }

    private void fillTafiretesDropdown(bool edit)
    {
        using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista = (
                    from item in db.Tafiletes
                    where item.Hab == true
                    select new SelectListItem
                    {
                        Text = item.NomTafiletes,
                        Value = item.IdTafiletes.ToString()
                    }
                ).ToList();
            if (!edit) lista.Insert(0, new SelectListItem { Text = "Elige uno", Value = "0" });
            ViewBag.tafiretes = lista;
        }
    }
}
}
