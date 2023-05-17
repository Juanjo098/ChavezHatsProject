using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Insertar
{
    public class SimpleINST
    {
        [Required(ErrorMessage = "Este campo no puede quedar en blanco")]
        [Range(1, 32, ErrorMessage = "Este campo debe tener entre 1-32 caracteres")]
        public string nombre { get; set; }
    }
}
