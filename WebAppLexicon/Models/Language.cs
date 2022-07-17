using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string LangName { get; set; }
    }
}
