using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Clase
    {
        public Clase()
        {
            Sombreros = new HashSet<Sombrero>();
        }

        public int IdClase { get; set; }
        public string NomClase { get; set; } = null!;
        public bool? Hab { get; set; }

        public virtual ICollection<Sombrero> Sombreros { get; set; }
    }
}
