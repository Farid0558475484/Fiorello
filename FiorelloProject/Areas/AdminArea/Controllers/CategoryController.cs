using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.DAL;
//using FiorelloProject.Migrations;
using FiorelloProject.Models;


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

        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);

        }



        public IActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public IActionResult Create(string name)
        {

            return View($"{name}");

        }
    }
}