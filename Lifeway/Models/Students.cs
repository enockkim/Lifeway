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
        public int adm_no { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public string Class { get; set; }
        public string date_of_admission { get; set; }
        public string parent_name { get; set; }
        public string parent_contact { get; set; }
        public string alt_contact { get; set; }
        public string status { get; set; }
        public string former_school { get; set; }
        public string place_of_residence { get; set; }



    }
}
