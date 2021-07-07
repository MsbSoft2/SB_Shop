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
    public class IndexModel : PageModel
    {
        private ICategoryRepository _categoryRepository;

        public IndexModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public IEnumerable<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _categoryRepository.GetAllCategory();
        }
    }
}
