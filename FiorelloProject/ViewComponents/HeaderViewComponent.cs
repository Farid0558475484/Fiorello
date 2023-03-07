using System;
using FiorelloProject.DAL;
//using FiorelloProject.Migrations;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.Models;
using FiorelloProject.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace FiorelloProject.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<AppUser> _userManager;

		public HeaderViewComponent(AppDbContext appDbContext, UserManager<AppUser> userManager)
		{
			_appDbContext = appDbContext;
            _userManager = userManager;
        }

  

        public async Task<IViewComponentResult> InvokeAsync()
		{

			ViewBag.Fulname = string.Empty;
			if(User.Identity.IsAuthenticated)
			{
				AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
				ViewBag.Fulname = user.Fulname;
			}

            Bio bio = _appDbContext.Bios.FirstOrDefault();
			return View(await Task.FromResult(bio));
		}

    }
}

