using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class InfoEnvio
    {
        public int IdInfoEnvio { get; set; }
        public string Telefono { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Colonia { get; set; } = null!;
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string CodigoPostal { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public bool? Hab { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
