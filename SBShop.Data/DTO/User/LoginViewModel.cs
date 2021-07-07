using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Data.DTO.User
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(150)]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RemmberMe { get; set; }
    }
}
