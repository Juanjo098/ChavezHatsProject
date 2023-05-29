using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class VentaCONS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name ="Fecha")]
        public string fecha { get; set; }
        [Display(Name ="Total")]
        public float total { get; set; }
        [ScaffoldColumn(false)]
        public DateTime dateTime { get; set; }
    }
}
