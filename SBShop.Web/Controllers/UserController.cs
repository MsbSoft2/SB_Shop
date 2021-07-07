using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SBShop.Data.DTO.User;
using SBShop.Data.Models;
using SBShop.Data.Repositories;

namespace SBShop.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(AddEditUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var addUser = new User()
            {
                FullName = user.FullName,
                Password = user.Password,
                Mobile = user.Mobile,
                Email = user.Email.ToLower(),
                IsActive = false,
                Type = 2
            };
            var res = _userRepository.InsertUser(addUser);
            return Redirect("/");
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var userLogined = _userRepository.LoginUser(user.Email.ToLower(), user.Password);
            if (userLogined == null)
            {
                ModelState.AddModelError("Email", "کاربر گرامی شما فعال نیستید");
                return View(user);
            }

            #region Authentication

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,userLogined.UserId.ToString()),
                new Claim("IsAdmin",(userLogined.Type == 1) ? "True":"False"),
                new Claim(ClaimTypes.Name,userLogined.Email),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = user.RemmberMe
            };

            await HttpContext.SignInAsync(principle, properties);

            #endregion


            return Redirect("/");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
