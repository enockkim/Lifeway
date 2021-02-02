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
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Student Name")]
        public string name { get; set; }
        public string dob { get; set; }
        [Required]
        public string Class { get; set; }
        public string date_of_admission { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Parent Name")]
        public string parent_name { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid Parent Contact")]
        public string parent_contact { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid Alternate Contact")]
        public string alt_contact { get; set; }
        public string status { get; set; }
        public string former_school { get; set; }
        public string place_of_residence { get; set; }



    }
}
