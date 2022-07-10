using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Identity
{
    public class AppRoles: IdentityUser
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
