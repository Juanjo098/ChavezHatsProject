using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class VentasUsuario
    {
        public int? IdVenta { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Hab { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual Ventum? IdVentaNavigation { get; set; }
    }
}
