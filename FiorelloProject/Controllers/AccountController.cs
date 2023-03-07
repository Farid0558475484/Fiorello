using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.Models;
using FiorelloProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloProject.Controllers
{
    public class AccountController : Controller
     
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

      

        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async  Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new();
            //user.Id = Guid.NewGuid().ToString();
            user.Fulname =register.Fulname;
            user.UserName = register.Username;
            user.Email = register.Email;
    

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View(register);
            }

            await _signInManager.SignInAsync(user,true);

            return RedirectToAction("index", "home");
        }






        public IActionResult Login()
        {
            return View();
        }



        public async  Task<IActionResult> Logout()
        {

           await _signInManager.SignOutAsync();

            return RedirectToAction("login");
        }

    }
}