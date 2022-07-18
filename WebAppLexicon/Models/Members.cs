using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members
{
    public class Members
    {
        public Members()
        { }
        [Key]
        public int MemberId { get; set; }
        public string MemberType { get; set; } //G: General 

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string GovIdType { get; set; }
        public string GovId { get; set; }
        public string? LoginId { get; set; }
        public string LoginName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; } 
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CtyId { get; set; }
        public int StateId { get; set; }
        public int CntyId { get; set; }
        public int LangId { get; set; }
        public int LangRead1 { get; set; } // 0: None 1:Beginer 2: Intermediate 3: Advance
        public int LangWrite1 { get; set; }
        public string MemberApproval { get; set; } // "A: Approve", "P: Pending", "S: Suspended" "T: Terminated"
        public DateTime MemberDate { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public List<Skills> SkillSet { get; set; }
        //Add Language2, 3 at later stage

        // Add image table link at later stage


    }
}
