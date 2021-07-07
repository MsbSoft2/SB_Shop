using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBShop.Data.DTO.User;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Web.Pages.Admin
{
    [Authorize]
    public class EditModel : PageModel
    {
        
        private IUserRepository _userRepository;

        public EditModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public AddEditUserViewModel user { get; set; }
        public void OnGet(int id)
        {
            var getUser = _userRepository.GetUserById(id);
            int Uid = getUser.UserId;
            user = new AddEditUserViewModel()
            {
                UserId = getUser.UserId,
                FullName = getUser.FullName,
                Email = getUser.Email,
                Mobile = getUser.Mobile,
                Password = getUser.Password,
                Type = getUser.Type,
                IsActive = getUser.IsActive
            };
        }

        public IActionResult OnPost()
        {
            var user1 = new User()
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                Mobile = user.Mobile,
                Password = user.Password,
                Type = user.Type,
                IsActive = user.IsActive
            };
            bool res = _userRepository.UpdateUser(user1);
            return RedirectToPage("Index");
        }
    }
}
