using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBShop.Data.DTO.Category;
using SBShop.Data.Models;

namespace SBShop.Data.Repositories
{
   public interface ICategoryRepository
   {
       IEnumerable<Category> GetAllCategory();
       Category FindCategoryById(int categoryId);
       void AddCategory(Category category);
       void DeleteCategory(Category category);
       void DeleteCategory(int categoryId);

       int GetCountGroup(int categoryId);
       IEnumerable<ShowCategoryGroupViewModel> GetCategoryForShow();

       string GetCategoryNameById(int categoryId);
   }
}
