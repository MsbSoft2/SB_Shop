using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBShop.Data.Models;

namespace SBShop.Data.Context
{
    public class SBShopContext : DbContext
    {
        public SBShopContext(DbContextOptions<SBShopContext> options) : base(options) { }

        #region Db Sets

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User

            _ = modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    FullName = "محمد صدرا برومند",
                    Password = "123",
                    Email = "sadrabroo@gmail.com",
                    Mobile = "09140286763",
                    Type = (int)UserTypeEnum.Admin,
                    IsActive = true
                }
                );

            #endregion

            #region User type

            modelBuilder.Entity<UserType>().HasKey(u => u.Type);
            modelBuilder.Entity<UserType>().HasData(
                new UserType()
                {
                    Type = 1,
                    Title = "Admin"
                },
                new UserType()
                {
                    Type = 2,
                    Title = "Customer"
                }
            );

            #endregion

            #region Category

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    Name = "پوشاک",
                    Description = "انواع پوشاک"
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "لوازم الکترونیکی",
                    Description = "انواع لوازم الکترونیکی"
                },
                new Category()
                {
                    CategoryId = 3,
                    Name = "مواد غذایی",
                    Description = "انواع مواد غذایی"
                }
                );

            #endregion

            #region Product

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 2,
                    Name = "محصول اول",
                    Description ="اولین محصول ایجاد شده از طریق پیشفرص برنامه می باشد" ,
                    Image = "Default.png",
                    Price = 100000
                });

            #endregion
        }
    }


}
