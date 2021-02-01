using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lifeway.Models
{
    public class Students
    {
        [Key]
        public int Adm_no { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
