using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Display(Name = "暱稱")]
        public override string UserName { get; set; }

        [Display(Name = "電子郵件")]
        public override string Email { get; set; }
    }
}