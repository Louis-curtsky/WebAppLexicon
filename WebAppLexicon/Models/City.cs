using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models
{
    public class City
    {
        public City()
        { }

        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("StateId")]
        public int? StateId { get; set; }

        public State States { get; set; }

        public List<State> StateList {get; set;}
    }
}
