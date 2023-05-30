using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Clases.Consultas;
using ProyectoFinal.Models;
using OfficeOpenXml;
using cm = System.ComponentModel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ProyectoFinal.Controllers
{
    public class VentaController : Controller
    {
        private static List<VentaCONS> consulta;

        public IActionResult Index()
        {
            return View(new List<VentaCONS>());
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

            consulta = lista;

            return View(lista);
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            VentaCONS v = getListaVenta().Find(e => e.id == id);

            if (v == null) return RedirectToAction("Error", "Home");

            ViewBag.usuario = GetUsuarioVenta(id);
            ViewBag.sombreros = GetListaSombreroVenta(id);

            return View(v);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Ventum venta = db.Venta.Find(id);

                    if (venta == null) return RedirectToAction("Error", "Home");

                    venta.Hab = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
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
                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private VentaCONS GetVenta(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    Ventum v = db.Venta.Find(id);

                    if (v == null) return null;

                    return new VentaCONS {
                        id = v.IdVenta,
                        fecha = v.FchVenta.ToString(),
                        total = (float)v.TotalVenta
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private UsuarioCONS GetUsuarioVenta(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    VentasUsuario v = db.VentasUsuarios.FirstOrDefault(e => e.IdVenta == id);

                    if (v == null) return null;

                    int idUsuario = (int)v.IdUsuario;
                    Usuario u = db.Usuarios.FirstOrDefault(e => e.IdUsuario == idUsuario);

                    return new UsuarioCONS {
                        id = u.IdUsuario,
                        nombre = u.NomUsuario,
                        correo = u.Correo,
                    };
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FileResult Exportar(string[] propiedades, int tipoReporte)
        {
            //string[] cabeceras = {"id", "nombre", "descripcion"};
            //string[] propiedades = {"id", "nombre", "descripcion"};
            byte[] data;
            switch (tipoReporte)
            {
                //Word
                case 1:
                    return null;
                //PDF
                case 2:
                    data = ExportarDatosPDF(propiedades, consulta);
                    return File(data, "application/pdf");
                //Excel
                case 3:
                    data = ExportarDatosExcel(/*cabeceras,*/ propiedades, consulta);
                    return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            return null;
        }

        public byte[] ExportarDatosExcel<T>(/*string[] cabeceras,*/ string[] propiedades, List<T> lista)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage ep = new ExcelPackage())
                {
                    ep.Workbook.Worksheets.Add("Hoja");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                    Dictionary<string, string> diccionario = cm.TypeDescriptor.GetProperties(typeof(T))
                        .Cast<cm.PropertyDescriptor>()
                        .ToDictionary(p => p.Name, p => p.DisplayName);

                    for (int i = 1; i <= propiedades.Length; i++)
                    {
                        ew.Cells[1, i].Value = diccionario[propiedades[i - 1]];
                    }

                    int fila = 2, col = 1;
                    foreach (object item in lista)
                    {
                        col = 1;
                        foreach (string prop in propiedades)
                        {
                            ew.Cells[fila, col].Value = item.GetType().GetProperty(prop).GetValue(item).ToString();
                            col++;
                        }
                        fila++;
                    }

                    ew.Column(1).AutoFit();
                    ew.Column(2).AutoFit();
                    ew.Column(3).AutoFit();

                    ep.SaveAs(ms);
                    byte[] data = ms.ToArray();
                    return data;
                }
            }
        }

        public byte[] ExportarDatosPDF<T>(string[] nombrePropiedades, List<T> lista)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Dictionary<string, string> diccionario = cm.TypeDescriptor.GetProperties(typeof(T))
                    .Cast<cm.PropertyDescriptor>()
                    .ToDictionary(p => p.Name, p => p.DisplayName);
                PdfWriter writer = new PdfWriter(ms);
                using (var pdfDoc = new PdfDocument(writer))
                {
                    //Vamos a crear un documento de PDF con un encabezado
                    Document doc = new Document(pdfDoc);
                    Paragraph p1 = new Paragraph("Reporte PDF");
                    p1.SetFontSize(20);
                    p1.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    doc.Add(p1);

                    iText.Layout.Element.Table table = new iText.Layout.Element.Table(nombrePropiedades.Length);
                    Cell cell;

                    for (int i = 0; i < nombrePropiedades.Length; i++)
                    {
                        cell = new Cell();
                        cell.Add(new Paragraph(diccionario[nombrePropiedades[i]]));
                        table.AddHeaderCell(cell);
                    }

                    //Datos de la tabla
                    foreach (object item in lista)
                    {
                        foreach (string prop in nombrePropiedades)
                        {
                            cell = new Cell();

                            if (item.GetType().GetProperty(prop).GetValue(item) != null)
                            {
                                cell.Add(new Paragraph(
                                    item.GetType().GetProperty(prop).GetValue(item).ToString()
                                ));
                            }
                            else
                            {
                                cell.Add(new Paragraph("--------"));
                            }
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                    writer.Close();
                }
                return ms.ToArray();
            }
        }

        private List<SomberoVentaCONS> GetListaSombreroVenta(int id)
        {
            try
            {
                using (CHAVEZ_HATSContext db = new CHAVEZ_HATSContext())
                {
                    List<SomberoVentaCONS> lista = (
                        from sombrero in db.Sombreros
                        join venta in db.VentasSombreros
                        on sombrero.IdSombrero equals venta.IdSombrero
                        join modelo in db.Modelos
                        on sombrero.IdModelo equals modelo.IdModelo
                        join clase in db.Clases
                        on sombrero.IdClase equals clase.IdClase
                        where sombrero.Hab == true && venta.IdVenta == id
                        select new SomberoVentaCONS
                        { 
                            id = sombrero.IdSombrero,
                            clase = clase.NomClase,
                            modelo = modelo.NomModelo,
                            precio = (float)venta.Precio,
                            unidades = (int)venta.UndVendidas,
                            subTotal = (float)venta.Precio * (int)venta.UndVendidas
                        }).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
