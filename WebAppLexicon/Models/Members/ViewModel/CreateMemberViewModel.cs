using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.ViewModel
{
    public class CreateMemberViewModel
    {
        public int MemberId { get; set; }
        
        [Required]
        [StringLength(50)]
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
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
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


        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
        [Required]
        public int CtyId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int CntyId { get; set; }
        public string MemberApproval { get; set; }
        public DateTime MemberDate { get; set; }
        public int LangId { get; set; }
        public int LangRead1 { get; set; } // 0: None 1:Beginer 2: Intermediate 3: Advance
        public int LangWrite1 { get; set; }
    }
}
