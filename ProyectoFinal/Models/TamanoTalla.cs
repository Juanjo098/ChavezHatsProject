using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class TamanoTalla
    {
        public TamanoTalla()
        {
            Sombreros = new HashSet<Sombrero>();
        }

        public int IdTamTalla { get; set; }
        public int IdTalla { get; set; }
        public int TamTalla { get; set; }
        public bool? Hab { get; set; }

        public virtual Talla IdTallaNavigation { get; set; } = null!;
        public virtual ICollection<Sombrero> Sombreros { get; set; }
    }
}
