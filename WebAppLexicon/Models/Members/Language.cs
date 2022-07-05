using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string LangName { get; set; }

        public List<MemberLanguage> MemberLanguage { get; set; }
    }
}
