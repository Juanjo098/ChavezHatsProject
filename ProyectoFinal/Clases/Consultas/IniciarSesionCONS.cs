using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class IniciarSesionCONS
    {
        [Display(Name="Correo")]
        [Required(ErrorMessage ="Introdusca su correo electrónico")]
        public string correo { get; set; }
        [Display(Name="Contraseña")]
        [Required(ErrorMessage ="Introdusca su contraseña")]
        public string contrasena { get; set; }
    }
}
