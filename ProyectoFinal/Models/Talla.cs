using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Talla
    {
        public Talla()
        {
            Sombreros = new HashSet<Sombrero>();
            TamanoTallas = new HashSet<TamanoTalla>();
        }

        public int IdTalla { get; set; }
        public string? NomTalla { get; set; }
        public bool? Hab { get; set; }

        public virtual ICollection<Sombrero> Sombreros { get; set; }
        public virtual ICollection<TamanoTalla> TamanoTallas { get; set; }
    }
}
