using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Sombreros = new HashSet<Sombrero>();
        }

        public int IdModelo { get; set; }
        public string NomModelo { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Sombrero> Sombreros { get; set; }
    }
}
