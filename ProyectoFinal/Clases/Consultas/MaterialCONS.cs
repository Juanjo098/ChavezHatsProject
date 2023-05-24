using NuGet.Protocol.Plugins;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Consultas
{
    public class MaterialCONS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name ="Toquilla")]
        public string toquilla { get; set; }
        [Display(Name ="Forro")]
        public string forro { get; set; }
        [Display(Name ="Barbiquejo")]
        public string barbiquejo { get; set; }
        [Display(Name ="Tafiretes")]
        public string tafiretes { get; set; }
        [Display(Name ="Ojitos")]
        public string ojitos { get; set; }
        [Display(Name ="Resorte")]
        public string resorte { get; set; }
        [ScaffoldColumn(false)]
        public int idToquilla { get; set; }
        [ScaffoldColumn(false)]
        public int idForro { get; set; }
        [ScaffoldColumn(false)]
        public int idBarbiquejo { get; set; }
        [ScaffoldColumn(false)]
        public int idTafiretes { get; set; }
    }
}
