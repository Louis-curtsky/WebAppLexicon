using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members
{
    public class MemberLanguage
    {
        [Key]
        public int ID { get; set; }
        public int MemberId { get; set; }
        public Members Members { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
