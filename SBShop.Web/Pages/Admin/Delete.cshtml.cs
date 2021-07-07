using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SBShop.Data.Repositories;

namespace SBShop.Web.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private IUserRepository _userRepository;

        public DeleteModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult OnGet(int userId)
        {
            _userRepository.DeleteUser(userId);
            return RedirectToPage("Index");
        }
    }
}
