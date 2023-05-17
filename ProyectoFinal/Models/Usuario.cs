using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? NomUsuario { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int IdTipoUsuario { get; set; }
        public bool? Hab { get; set; }

        public virtual TiposUsario IdTipoUsuarioNavigation { get; set; } = null!;
        public virtual InfoEnvio? InfoEnvio { get; set; }
    }
}
