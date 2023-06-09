﻿using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class SombreroController : Controller
    {
        public IActionResult Index()
        {
            List<SombreroCONS> lista = GetListaSombreros();

            if (lista == null) return RedirectToAction("Error", "Home");

            return View(lista);
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            SombreroCONSD sombrero = GetSombreroDetallado(id);

            if (sombrero == null) return RedirectToAction("Error", "Home");

            return View(sombrero);
        }

        private List<SombreroCONS> GetListaSombreros()
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<SombreroCONS> lista = (
                            from item in db.Sombreros
                            join tam in db.TamanoTallas
                            on item.IdTamTalla equals tam.IdTamTalla
                            join talla in db.Tallas
                            on tam.IdTalla equals talla.IdTalla
                            join clase in db.Clases
                            on item.IdClase equals clase.IdClase
                            join modelo in db.Modelos
                            on item.IdModelo equals modelo.IdModelo
                            where item.Hab == true
                            select new SombreroCONS {
                                id = item.IdSombrero,
                                idMaterial = item.IdMaterial,
                                nomModelo = modelo.NomModelo,
                                nomClase = clase.NomClase,
                                nomTalla = talla.NomTalla,
                                tamTalla = tam.TamTalla,
                                medFalda = (float)item.MedFalda,
                                precio = (float)item.Precio,
                                stock = (int)item.Stock,
                                personalizado = (bool)item.Personalizado? "Sí" : "No",
                                idModelo = item.IdModelo,
                                idClase = item.IdClase,
                                idTamTalla = item.IdTamTalla,
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

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Sombrero sombrero = db.Sombreros.Find(id);

                    if (sombrero == null) return RedirectToAction("Error", "Home");

                    sombrero.Hab = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        private List<SombreroCONSD> GetListaSombrerosDetallada()
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
                                idModelo = item.IdModelo,
                                idClase = item.IdClase,
                                idTamTalla = item.IdTamTalla,
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

        private SombreroCONSD GetSombreroDetallado(int id)
        {
            List<SombreroCONSD> lista = GetListaSombrerosDetallada();

            if (lista == null) return null;

            return lista.Find(e => e.id == id);
        }
    }
}
