using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBShop.Data.Repositories;

namespace SBShop.Web.Controllers
{
    public class ShowProductController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ShowProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        //[Route("{id}/{name}")]
        public IActionResult ShowProduct(int id, string name)
        {
            return View(_productRepository.GetShowListProductById(id));
        }

        [Route("ShowProductsByCategory/{categoryId}")]
        public IActionResult ShowProductsByCategory(int categoryId)
        {
            ViewData["categoryName"] = _categoryRepository.GetCategoryNameById(categoryId);
            return View(_productRepository.ShowProductsByCategoryId(categoryId));
        }
    }
}
