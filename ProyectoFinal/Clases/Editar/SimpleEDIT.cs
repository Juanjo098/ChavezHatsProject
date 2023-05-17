using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Editar
{
    public class SimpleEDIT
    {
        public int id { get; set; }
        [Display(Name ="Nombre")]
        [Required(ErrorMessage = "Este campo no puede quedar en blanco")]
        public string nombre { get; set; }
    }
}
