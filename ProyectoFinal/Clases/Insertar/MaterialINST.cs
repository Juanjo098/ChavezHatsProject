using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Insertar
{
    public class MaterialINST
    {
        [Display(Name ="Toquilla")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe elegir una opción que no sea la predeterminada")]
        public int idToquilla { get; set; }
        [Display(Name ="Forro")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe elegir una opción que no sea la predeterminada")]
        public int idForro { get; set; }
        [Display(Name ="Barbiquejo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe elegir una opción que no sea la predeterminada")]
        public int idBarbiquejo { get; set; }
        [Display(Name ="Tafirete")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe elegir una opción que no sea la predeterminada")]
        public int idTafirete { get; set; }
        [Display(Name ="Ojillos")]
        public bool ojillos { get; set; }
        [Display(Name ="Resorte")]
        public bool resorte { get; set; }
    }
}
