using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Web.Pages.Categories
{
    public class AddCategoryModel : PageModel
    {
        private ICategoryRepository _categoryRepository;

        public AddCategoryModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _categoryRepository.AddCategory(Category);
            return Redirect("/Categories");
        }
    }
}
