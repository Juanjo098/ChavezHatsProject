using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class ProductoCONS
    {
        [Display(Name ="Modelo")]
        public string modelo { get; set; }
        [Display(Name ="Clase")]
        public string clase { get; set; }
        [Display(Name ="Precio")]
        public float precio { get; set; }
        [Display(Name ="Stock")]
        public int strock { get; set; }
        [Display(Name ="Talla")]
        public int talla { get; set; }
        [ScaffoldColumn(false)]
        public string imagen { get; set; }
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [ScaffoldColumn(false)]
        public int idModelo { get; set; }
        [ScaffoldColumn(false)]
        public int idClase { get; set; }        
        [ScaffoldColumn(false)]
        public int idTalla { get; set; }

        public bool Comparar(ProductoCONS item)
        {
            if (item.idModelo != 0 && item.idModelo != idModelo) return false;
            if (item.idClase != 0 && item.idClase != idClase) return false;
            if (item.idTalla != 0 && item.idTalla != idTalla) return false;
            return true;
        }
    }
}
