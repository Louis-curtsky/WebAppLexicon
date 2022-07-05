using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string memberType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string GovIdType { get; set; }
        public string GovId { get; set; }
        public string LoginName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; } 
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CtyId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public List<MemberLanguage> language1 { get; set; }
        public int langRead1 { get; set; } // 0: None 1:Beginer 2: Intermediate 3: Advance
        public int langWrite1 { get; set; }
        //Add Language2, 3 at later stage

        // Add image table link at later stage

    }
}
