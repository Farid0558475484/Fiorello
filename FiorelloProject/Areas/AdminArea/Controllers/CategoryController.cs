using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.DAL;

namespace FiorelloProject.Areas.AdminArea.Controllers
{
    
    [Area("AdminArea")]

    
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            //return View();
            return View(_appDbContext.Categories.ToList());
        }
    }
}