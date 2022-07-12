using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members
{
    public class SkillCats
    {
        public SkillCats() {}
        [Key]
        public int SkillId { get; set; }
        public string Categories { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
