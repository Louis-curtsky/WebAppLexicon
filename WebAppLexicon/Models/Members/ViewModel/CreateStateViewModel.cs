using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateStateViewModel
    {
        [Required]
        [Display(Name = "State")]
        public String StateName { get; set; }

        [Required]
        [Display(Name = "Country ID")]
        public int CntyId { get; set; }
        public Country Country { get; set; }
        public List<Country> CountryList { get; set; }

        public CreateStateViewModel()
        {
        }
    }
}
