using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Data.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        public Student Student { get; set; }

        public Section Section { get; set; }

    }
}
