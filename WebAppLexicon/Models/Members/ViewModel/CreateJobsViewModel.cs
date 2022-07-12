using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateJobsViewModel
    {
        [Required]
        [StringLength(255)]
        [Display(Name="Job Description")]
        public string JobDesc { get; set; }
        [Required]
        [Display(Name = "Skill")]
        public int SkillId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Remarks")]
        public string JobComments { get; set; }
    }
}
