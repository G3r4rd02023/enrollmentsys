using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Data.Entities
{
    public class Section
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Hour { get; set; }        

        [Display(Name = "Aula")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Room { get; set; }

        [Display(Name = "Cupos")]
        public int Cupos { get; set; }

        public Teacher Teacher { get; set; }
    }
}
