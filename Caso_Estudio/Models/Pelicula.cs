using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Caso_Estudio.Models
{
    public class Pelicula
    {
        [Display(Name = "Codigo Pelicula")]
        public int PeliculaID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name ="Director")]
        public string Director { get; set; }

        [Required]
        [Display(Name = "Fecha de Estreno")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double Price { get; set; }

        public virtual VideoClub VideoClub { get; set; }
        public virtual Alquiler Alquiler { get; set; }
    }
}