using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Data.DTO.User
{
    public class AddEditUserViewModel
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "نام کامل")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }
        [Required]
        [Display(Name = "نوع حساب")]
        public int Type { get; set; }
        [Display(Name = "وضعیت حساب")]
        public bool IsActive { get; set; }
    }
}
