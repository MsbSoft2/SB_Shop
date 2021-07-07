using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBShop.Data.DTO.Product;
using SBShop.Data.Models;

namespace SBShop.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ShowListProduct> GetAllProduct();
        ShowListProduct GetShowListProductById(int id);
        Product GetProductById(int productId);
        bool InsertProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        void DeleteProduct(int productId);

        IEnumerable<ShowListProduct> ShowProductsByCategoryId(int categoryId);
    }
}
