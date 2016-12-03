using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Caso_Estudio.Models
{
    public class Alquiler
    {
        [Display(Name = "Codigo Alquiler")]
        public int AlquilerID { get; set; }

        [Required]
        [Display(Name = "Fecha de Recogida")]
        [DataType(DataType.Date)]
        public DateTime PickUpate { get; set; }

        [Required]
        [Display(Name = "Fecha de Devolución")]
        [DataType(DataType.Date)]
        public DateTime DateOfReturn { get; set; }


        [Required]
        [Display(Name = "Total a Pagar")]
        public float Cost { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}