using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class SombreroCONS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name ="ID Material")]
        public int idMaterial { get; set; }
        [Display(Name ="Modelo")]
        public string nomModelo { get; set; }
        [Display(Name ="Clase")]
        public string nomClase { get; set;}
        [Display(Name ="Talla")]
        public string nomTalla { get; set; }        
        [Display(Name ="Medida de talla")]
        public int tamTalla { get; set; }
        [Display(Name ="Medida de falda")]
        public float medFalda { get; set; }
        [Display(Name ="Precio")]
        public float precio { get; set; }
        [Display(Name ="Stcok")]
        public int stock { get; set; }
        [Display(Name ="Personalizado")]
        public string personalizado { get; set; }
        [ScaffoldColumn(false)]
        public int idModelo { get; set; }
        [ScaffoldColumn(false)]
        public int idClase { get; set; }
        [ScaffoldColumn(false)]
        public int idTamTalla { get; set; }
    }
}
