using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class VentasSombrero
    {
        public int? IdVenta { get; set; }
        public int? IdSombrero { get; set; }
        public decimal? Precio { get; set; }
        public int? UndVendidas { get; set; }

        public virtual Sombrero? IdSombreroNavigation { get; set; }
        public virtual Ventum? IdVentaNavigation { get; set; }
    }
}
