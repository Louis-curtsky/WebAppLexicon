using System;
using System.ComponentModel.DataAnnotations;


namespace WebAppLexicon.Models.Identity.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 6)]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required]
        [Display(Name = "Member ID")]
        public int MemberId { get; set; }
    }
}
