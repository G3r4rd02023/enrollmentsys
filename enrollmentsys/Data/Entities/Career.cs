using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Data.Entities
{
    public class Career
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Code { get; set; }

        [Display(Name = "Carrera")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        [Display(Name = "Logo")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? $"https://localhost:44301/images/noimage.png"
            : $"https://localhost:44301{ImageUrl[1..]}";
            //: $"https://workshopvehicles.azurewebsites.net{ImageUrl.Substring(1)}";

        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
