using System.ComponentModel.DataAnnotations;

namespace Caso_Estudio.Models
{
    public class Socio
    {
        [Display(Name = "Codigo Socio")]
        public int SocioID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }
    }
}