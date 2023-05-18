using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Insertar
{
    public class UsuarioINST
    {
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="Este campo no puede quedar vacío")]
        public string nombre { get; set; }
        [Display(Name ="Correo")]
        [Required(ErrorMessage ="Este campo no puede quedar vacío")]
        [RegularExpression(@"^[a-z0-9]+@[a-z]+(\.[a-z]{2,3})+$", ErrorMessage ="No cumple con el patrón de formación de un correo electrónico")]
        public string correo { get; set; }
        [Display(Name ="Contraseña")]
        [Required(ErrorMessage ="Este campo no puede quedar vacío")]
        [StringLength(16, MinimumLength =8, ErrorMessage ="La contraseña debe contener entre 8 y 6 caracteres")]
        public string contrasena { get; set; }
    }
}
