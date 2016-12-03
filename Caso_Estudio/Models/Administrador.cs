using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Caso_Estudio.Models
{
    public class Administrador
    {
        [Display(Name = "Codigo Administrador")]
        public int AdministradorID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}