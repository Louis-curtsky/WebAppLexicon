using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        public CreateCountryViewModel() { }

        public CreateCountryViewModel(Country country)
        {
            CountryName = country.CntyName;
        }
    }
}
