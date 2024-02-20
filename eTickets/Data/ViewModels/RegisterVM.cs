using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "請輸入姓名")]
        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "這不是有效的Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "電子郵件")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請輸入確認密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "再次輸入密碼")]
        [Compare("Password", ErrorMessage = "兩次密碼輸入不同，請重新確認")]
        public string ConfirmPassword { get; set; }
    }
}