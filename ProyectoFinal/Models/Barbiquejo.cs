using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Barbiquejo
    {
        public Barbiquejo()
        {
            Materials = new HashSet<Material>();
        }

        public int IdBarbiquejo { get; set; }
        public string NomBarbiquejo { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
