using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShop.Data.Models
{
    public class UserType
    {
        //[Key]
        public int Type { get; set; }
        public string Title { get; set; }

        public List<User> Users { get; set; }
    }
    public enum UserTypeEnum
    {
        Admin = 1,
        Customer = 2
    }
}
