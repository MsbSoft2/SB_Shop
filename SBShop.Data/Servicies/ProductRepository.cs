using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBShop.Data.Context;
using SBShop.Data.DTO.Product;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Data.Servicies
{
    public class ProductRepository : IProductRepository
    {
        private SBShopContext db;

        public ProductRepository(SBShopContext db)
        {
            this.db = db;
        }

        public IEnumerable<ShowListProduct> GetAllProduct()
        {
            return db.Products.Select(p => new ShowListProduct()
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                CategoryName = db.Categories
                    .FirstOrDefault(c => c.CategoryId == p.CategoryId).Name
            });
        }

        public ShowListProduct GetShowListProductById(int id)
        {
            return db.Products.Select(p => new ShowListProduct()
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Price = p.Price,
                CategoryName = db.Categories
                        .Single(c => c.CategoryId == p.CategoryId).Name
            }).FirstOrDefault(p => p.ProductId == id);

        }

        public Product GetProductById(int productId)
        {
            return db.Products.Find(productId);
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            DeleteProduct(product);
        }

        public IEnumerable<ShowListProduct> ShowProductsByCategoryId(int categoryId)
        {
            return db.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ShowListProduct()
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
                    CategoryName = db.Categories
                        .FirstOrDefault(c => c.CategoryId == p.CategoryId)
                        .Name
                });
        }
    }
}
