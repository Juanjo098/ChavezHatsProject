using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class TiposUsario
    {
        public TiposUsario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomTipoUsuario { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
