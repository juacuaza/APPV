using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caso_Estudio.Models
{
    public class Cadena
    {
        [Required]
        [Display(Name = "Código")]
        public int CadenaID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Código Postal")]
        public string Zip { get; set; }
    }
}