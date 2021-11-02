using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public User User { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]        
        public DateTime BirthDay { get; set; }
             
        public Career Career { get; set; }


    }
}
