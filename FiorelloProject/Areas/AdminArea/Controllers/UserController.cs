using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class UserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
    }
}