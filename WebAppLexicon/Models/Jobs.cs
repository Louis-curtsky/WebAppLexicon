using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models
{
    public class Jobs
    {
        public Jobs() { }
        [Key]
        public int JobId { get; set; }
        public DateTime JobRecordDate { get; set; }
        [ForeignKey ("MemberId")]
        public int MemberId { get; set; }
        public string JobDesc { get; set; }
        public int SkillId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobComments { get; set; }
        public int ChatId { get; set; }
        public Skills Skills { get; set; }
        public WebAppLexicon.Models.Members.Members Members { get; set; }
    }
}
