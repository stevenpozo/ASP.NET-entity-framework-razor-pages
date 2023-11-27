using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRazor.Models.ViewModel
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras y espacios en el nombre.")]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La edad es obligatoria.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se permiten números enteros en la edad.")]
        [DisplayName("Edad")]
        public int? Age { get; set; }
    }
}