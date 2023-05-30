using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class SomberoVentaCONS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name ="Modelo")]
        public string modelo { get; set; }
        [Display(Name ="Clase")]
        public string clase { get; set; }
        [Display(Name ="Precio")]
        public float precio { get; set; }
        [Display(Name ="Unidades")]
        public int unidades { get; set; }
        [Display(Name ="Subtotal")]
        public float subTotal { get; set; }
    }
}
