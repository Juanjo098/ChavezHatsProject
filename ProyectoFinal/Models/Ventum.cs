using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Ventum
    {
        public int IdVenta { get; set; }
        public DateTime? FchVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public bool? Hab { get; set; }
    }
}
