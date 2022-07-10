using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData] 
        public int MemberId { get; set; }
        public string UserRolesId { get; set; }
    }
}
