using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Tafilete
    {
        public Tafilete()
        {
            Materials = new HashSet<Material>();
        }

        public int IdTafiletes { get; set; }
        public string NomTafiletes { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
