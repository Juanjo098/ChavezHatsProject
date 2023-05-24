using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Editar
{
    public class MaterialEDIT
    {
        [Display(Name ="ID")]
        [Range(1, int.MaxValue, ErrorMessage ="El ID no es válido")]
        public int id { get; set; }
        [Display(Name ="Toquilla")]
        [Range(1, int.MaxValue, ErrorMessage ="El ID no es válido")]
        public int idToquilla { get; set; }
        [Display(Name ="Forro")]
        [Range(1, int.MaxValue, ErrorMessage ="El ID no es válido")]
        public int idForro { get; set; }
        [Display(Name ="Barbiquejo")]
        [Range(1, int.MaxValue, ErrorMessage ="El ID no es válido")]
        public int idBarbiquejo { get; set; }
        [Display(Name ="Tafiretes")]
        [Range(1, int.MaxValue, ErrorMessage ="El ID no es válido")]
        public int idTafirete { get; set; }
        [Display(Name ="Ojillos")]
        public bool ojillos { get; set; }
        [Display(Name ="Resorte")]
        public bool resorte { get; set; }
    }
}
