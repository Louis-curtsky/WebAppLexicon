using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateSkillsViewModel
    {

        [StringLength(255)]
        [Display(Name = "Skill Description")]
        public string SkillDesc { get; set; }
        [Required]
        [Display(Name ="Skill Level")]
        public int SkillLevel { get; set; }
        [Required]
        [Display(Name = "Skill Years")]
        public int SkillYears { get; set; }
    }
}
