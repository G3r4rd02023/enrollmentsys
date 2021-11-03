using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar Contraseña")]
        public bool RememberMe { get; set; }
    }
}
