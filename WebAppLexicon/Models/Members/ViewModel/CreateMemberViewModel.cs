using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateMemberViewModel
    {
        [Required]
        [StringLength(1)]
        public string MemberType { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Type of Government ID")]
        public string GovIdType { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Government ID")]
        public string GovId { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Login")]
        public string LoginName { get; set; }

        [Required]
        [Display(Name = "Login")]
        public int Age { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        public int CtyId { get; set; }
        public int StateId { get; set; }
        public int CntyId { get; set; }
        public List<MemberLanguage> language1 { get; set; }
        public int langRead1 { get; set; } // 0: None 1:Beginer 2: Intermediate 3: Advance
        public int langWrite1 { get; set; }
    }
}
