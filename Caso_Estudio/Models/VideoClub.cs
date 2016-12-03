using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Caso_Estudio.Models
{
    public class VideoClub
    {
        [Display(Name = "Codigo")]
        public int VideoClubID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required]
        [MaxLength(5)]
        [DataType(DataType.PostalCode)]
        [Display(Name ="Codigo Postal")]
        public string Zip { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}