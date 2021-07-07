using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBShop.Data.Repositories;

namespace SBShop.Web.Components
{
    public class ShowGroupComponents:ViewComponent
    {
        private ICategoryRepository _categoryRepository;

        public ShowGroupComponents(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ShowGroupComponents.cshtml", _categoryRepository.GetCategoryForShow());
        }
    }
}
