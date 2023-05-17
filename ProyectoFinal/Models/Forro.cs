using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Forro
    {
        public Forro()
        {
            Materials = new HashSet<Material>();
        }

        public int IdForro { get; set; }
        public string NomForro { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
