using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Display(Name = "Country")]
        public int CntyId { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Display(Name = "City")]
        public int CtyId { get; set; }

    }
}
