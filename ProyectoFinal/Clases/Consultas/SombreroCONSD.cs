using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Clases.Consultas
{
    public class SombreroCONSD
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Modelo")]
        public string nomModelo { get; set; }
        [Display(Name = "Clase")]
        public string nomClase { get; set; }
        [Display(Name = "Toquilla")]
        public string toquilla { get; set; }
        [Display(Name = "Forro")]
        public string forro { get; set; }
        [Display(Name = "Barbiquejo")]
        public string barbiquejo { get; set; }
        [Display(Name = "Tafiretes")]
        public string tafiretes { get; set; }
        [Display(Name = "Ojitos")]
        public string ojitos { get; set; }
        [Display(Name = "Resorte")]
        public string resorte { get; set; }

        [Display(Name = "Talla")]
        public string nomTalla { get; set; }
        [Display(Name = "Medida de talla")]
        public int tamTalla { get; set; }
        [Display(Name = "Medida de falda")]
        public float medFalda { get; set; }
        [Display(Name = "Precio")]
        public float precio { get; set; }
        [Display(Name = "Stcok")]
        public int stock { get; set; }
        [Display(Name = "Personalizado")]
        public string personalizado { get; set; }
        [ScaffoldColumn(false)]
        public string imagen { get; set; }
        [ScaffoldColumn(false)]
        public int idModelo { get; set; }
        [ScaffoldColumn(false)]
        public int idClase { get; set; }
        [ScaffoldColumn(false)]
        public int idTamTalla { get; set; }
    }
}
