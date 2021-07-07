using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBShop.Data.Context;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //[BindProperty]
        public List<User> Users = new List<User>();
        public void OnGet()
        {
            Users.AddRange(_userRepository.GetAllUsers());
        }
    }
}
