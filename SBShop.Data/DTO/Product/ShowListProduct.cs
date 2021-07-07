using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Data.DTO.Product
{
    public class ShowListProduct
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "نام محصول")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "توضیحات")]
        [DataType(DataType.Html)]
        //[AllowHtml]
        public string Description { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "گروه")]
        public string CategoryName { get; set; }
    }
}
