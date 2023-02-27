using System;
using FiorelloProject.DAL;
//using FiorelloProject.Migrations;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.Models;

namespace FiorelloProject.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		private readonly AppDbContext _appDbContext;

		public HeaderViewComponent(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			Bio bio = _appDbContext.Bios.FirstOrDefault();
			return View(await Task.FromResult(bio));
		}

    }
}

