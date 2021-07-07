using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SBShop.Data.DTO.Product;
using SBShop.Data.Models;
using SBShop.Data.Repositories;
using SBShop.Utility;

namespace SBShop.Web.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAllProduct());
        }

        #region Insert

        [Route("InsertProduct")]
        public IActionResult InsertProduct()
        {
            return View(new AddEditProductViewModel()
            {
                Name = "",
                Description = "",
                Price = 0,
                Categories = _categoryRepository.GetAllCategory().ToList()
            });
        }

        [HttpPost]
        [Route("InsertProduct")]
        public IActionResult InsertProduct(AddEditProductViewModel product)
        {
            Product addProduct;
            string imageName = "Default.png";

            if (product.Image != null)
            {
                var nameGenerator = Guid.NewGuid().ToString();

                imageName = nameGenerator + Path.GetExtension(product.Image.FileName);
                addProduct = new Product()
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Price = product.Price,
                    Image = imageName,
                };

                _productRepository.InsertProduct(addProduct);

                imageName = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    nameGenerator + Path.GetExtension(product.Image.FileName));

                using (FileStream stream = new FileStream(imageName, FileMode.Create))
                {
                    product.Image.CopyTo(stream);
                }
            }
            else
            {
                addProduct = new Product()
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Price = product.Price,
                    Image = imageName,
                };
                var res = _productRepository.InsertProduct(addProduct);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return View(new AddEditProductViewModel()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                OldImage = product.Image,
                Categories = _categoryRepository.GetAllCategory().ToList()
            });
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(AddEditProductViewModel product)
        {
            Product addProduct;
            string imageName = "Default.png";

            if (product.Image != null)
            {

                // TODO Delete Image File
                var res = DeleteFile.DeleteImageFile(Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "Images", product.OldImage));
                //End

                var nameGenerator = Guid.NewGuid().ToString();

                imageName = nameGenerator + Path.GetExtension(product.Image.FileName);
                addProduct = new Product()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Price = product.Price,
                    Image = imageName,
                };

                _productRepository.UpdateProduct(addProduct);

                imageName = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    nameGenerator + Path.GetExtension(product.Image.FileName));

                using (FileStream stream = new FileStream(imageName, FileMode.Create))
                {
                    product.Image.CopyTo(stream);
                }
            }
            else
            {
                addProduct = new Product()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Price = product.Price
                };
                var res = _productRepository.UpdateProduct(addProduct);
            }

            return RedirectToAction("Index");
        }

        #endregion

        [Route("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
            return RedirectToAction("Index");
        }
    }
}
