using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Sombrero
    {
        public int IdSombrero { get; set; }
        public int IdModelo { get; set; }
        public int IdClase { get; set; }
        public int IdMaterial { get; set; }
        public int IdTalla { get; set; }
        public double MedFalda { get; set; }
        public decimal Precio { get; set; }
        public int? Stock { get; set; }
        public string Imagen { get; set; } = null!;
        public bool? Personalizado { get; set; }
        public bool? Hab { get; set; }

        public virtual Clase IdClaseNavigation { get; set; } = null!;
        public virtual Material IdMaterialNavigation { get; set; } = null!;
        public virtual Modelo IdModeloNavigation { get; set; } = null!;
        public virtual Talla IdTallaNavigation { get; set; } = null!;
    }
}
