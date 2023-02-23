using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using FiorelloProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloProject.Controllers
{
    public class CommonController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public CommonController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Search(string search)
        {

            var products = _appDbContext.Products
                .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .ToList();
            return PartialView("_SearchPartial",products);
        }
    }
}