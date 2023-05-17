using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class SimpleCONS
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
    }
}
