﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Data.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Section> Sections { get; set; }


    }
}
