using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Code { get; set; }

        [Display(Name = "Clase")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Career Career { get; set; }

        public ICollection<Section> Sections { get; set; }

    }
}
