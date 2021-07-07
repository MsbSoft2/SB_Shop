using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBShop.Data.Context;
using SBShop.Data.DTO.Category;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Data.Servicies
{
    public class CategoryRepository : ICategoryRepository
    {
        private SBShopContext db;

        public CategoryRepository(SBShopContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return db.Categories;
        }

        public Category FindCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            db.Entry(category).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            DeleteCategory(FindCategoryById(categoryId));
        }

        public int GetCountGroup(int categoryId)
        {
            return db.Categories.Count(c => c.CategoryId == categoryId);
        }

        public IEnumerable<ShowCategoryGroupViewModel> GetCategoryForShow()
        {
            return db.Categories.Select(c => new ShowCategoryGroupViewModel()
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                CountGroup = db.Products.Count(p => p.CategoryId == c.CategoryId)
            }).ToList();
        }

        public string GetCategoryNameById(int categoryId)
        {
            return db.Categories
                .SingleOrDefault(c => c.CategoryId == categoryId)
                .Name;
        }
    }
}
