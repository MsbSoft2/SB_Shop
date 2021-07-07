using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBShop.Data.Context;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Data.Servicies
{
    public class UserRepository : IUserRepository
    {
        private SBShopContext db;

        public UserRepository(SBShopContext db)
        {
            this.db = db;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users;
        }

        public User GetUserById(int id)
        {
            return db.Users.Find(id);
        }

        public bool InsertUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            DeleteUser(user);
        }

        public User LoginUser(string email, string password)
        {
            return db.Users
                .SingleOrDefault(u => u.Email == email && u.Password == password && u.IsActive == true);
        }

        public List<string> ListEmailAdmin()
        {
            return db.Users.Select(u => u.Email).ToList();
        }
    }
}
