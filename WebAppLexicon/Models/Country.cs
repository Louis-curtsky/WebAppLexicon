using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models
{
    public class Country
    {
        public Country() { }

        [Key]
        public int CntyId { get; set; }
        public string CntyName { get; set; }

        public List<State> States { get; set; }
    }
}
