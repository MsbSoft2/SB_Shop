using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBShop.Data.Repositories;

namespace SBShop.Web.Pages.Categories
{
    public class DeleteCategoryModel : PageModel
    {
        private ICategoryRepository _category;

        public DeleteCategoryModel(ICategoryRepository category)
        {
            _category = category;
        }
        public IActionResult OnGet(int categoryId)
        {
            _category.DeleteCategory(categoryId);
            return Redirect("/categories");
        }
    }
}
