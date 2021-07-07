using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBShop.Data.Models;

namespace SBShop.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        void DeleteUser(int userId);
        User LoginUser(string email, string password);
        List<string> ListEmailAdmin();
    }
}
