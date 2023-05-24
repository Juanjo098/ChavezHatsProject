using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Talla
    {
        public Talla()
        {
            TamanoTallas = new HashSet<TamanoTalla>();
        }

        public int IdTalla { get; set; }
        public string? NomTalla { get; set; }
        public bool? Hab { get; set; }

        public virtual ICollection<TamanoTalla> TamanoTallas { get; set; }
    }
}
