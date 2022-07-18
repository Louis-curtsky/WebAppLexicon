using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateLanguageViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Language")]
        public string LangName { get; set; }
        public List<Members> MemberList { get; set; }

        public CreateLanguageViewModel() { }

        public CreateLanguageViewModel(Language language)
        {
            LangName = language.LangName;
        }
    }
}
