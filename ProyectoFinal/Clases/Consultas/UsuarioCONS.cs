using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class UsuarioCONS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Display(Name ="Correo")]
        public string correo { get; set; }
        [Display(Name ="Contraseña")]
        public string contrasena { get; set; }
        [Display(Name ="Tipo de usuario")]
        public string tipoUsuario { get; set; }
        [ScaffoldColumn(false)]
        public int idTipoUsuario { get; set; }
    }
}
