using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateSkillCatsViewModel
    {
        public int SkillId { get; set; }
        [Required]
        [StringLength(1)]
        public string Categories { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
