using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models
{
    public class State
    {
        public State() { }

        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        //[ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country Countries { get; set; }

        public List<City> Cities { get; set; }
    }
}
