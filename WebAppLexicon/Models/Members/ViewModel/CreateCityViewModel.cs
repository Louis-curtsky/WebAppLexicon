using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateCityViewModel
    {
        [Required]
        [Display(Name = "City")]
        public String CName { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public State State { get; set; }
        public List<State> StateList { get; set; }

        public CreateCityViewModel()
        {
        }
    }
}
