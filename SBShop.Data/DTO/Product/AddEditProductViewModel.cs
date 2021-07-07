using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SBShop.Data.Models;

namespace SBShop.Data.DTO.Product
{
    public class AddEditProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "نام محصول")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "توضیحات")]
        [DataType(DataType.Html)]
        public string Description { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile Image { get; set; }
        [Display(Name = "تصویر فعلی")]
        public string OldImage { get; set; }
        [Required]
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "گروه")]
        public int CategoryId { get; set; }
        public List<Models.Category> Categories { get; set; }
    }
}
