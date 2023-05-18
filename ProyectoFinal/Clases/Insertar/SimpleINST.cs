﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Clases.Insertar
{
    public class SimpleINST
    {
        [Display(Name ="Nombre")]
        [Required(ErrorMessage = "Este campo no puede quedar en blanco")]
        public string nombre { get; set; }
    }
}
