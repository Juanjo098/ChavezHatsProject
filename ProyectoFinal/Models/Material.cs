using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Material
    {
        public Material()
        {
            Sombreros = new HashSet<Sombrero>();
        }

        public int IdMaterial { get; set; }
        public int IdToquilla { get; set; }
        public int IdForro { get; set; }
        public int IdBarbiquejo { get; set; }
        public int IdTafiletes { get; set; }
        public bool Ojillos { get; set; }
        public bool Resorte { get; set; }
        public bool? Hab { get; set; }

        public virtual Barbiquejo IdBarbiquejoNavigation { get; set; } = null!;
        public virtual Forro IdForroNavigation { get; set; } = null!;
        public virtual Tafilete IdTafiletesNavigation { get; set; } = null!;
        public virtual Toquilla IdToquillaNavigation { get; set; } = null!;
        public virtual ICollection<Sombrero> Sombreros { get; set; }
    }
}
