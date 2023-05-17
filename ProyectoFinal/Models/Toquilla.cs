using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Toquilla
    {
        public Toquilla()
        {
            Materials = new HashSet<Material>();
        }

        public int IdToquilla { get; set; }
        public string NomToquilla { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
