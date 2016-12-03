using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Caso_Estudio.Models
{
    public class AlquilerSocio
    {
        [Display(Name = "Codigo Alguiler del Socio")]
        public int AlquilerSocioID { get; set; }

        [Required]
        [Display(Name = "fecha de Creación")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Total Gastado")]
        public float TotalSpent { get; set; }
    }
}