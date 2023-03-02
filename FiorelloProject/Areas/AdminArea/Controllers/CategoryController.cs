using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.DAL;
//using FiorelloProject.Migrations;
using FiorelloProject.Models;
using FiorelloProject.ViewModels;
//using FiorelloProject.Migrations;

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
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CategoryCreateVM category)
        {       if (!ModelState.IsValid) return View();
            bool isExit = _appDbContext.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());

            if (isExit)
            {
                ModelState.AddModelError("Name", "Bu addan artig var");
                return View();
            }
            Category newCategory = new()
            {
                Name = category.Name,
                Description = category.Description

            };
            _appDbContext.Categories.Add(newCategory);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }



        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(new CategoryUpdateVM { Name=category.Name, Description=category.Description});
        }



        [HttpPost]
        public IActionResult Edit(int id, CategoryUpdateVM updateVM)
        {


            if (id == null) return NotFound();
            Category existCategory = _appDbContext.Categories.Find(id);
            if (!ModelState.IsValid) return View();
            bool isExit = _appDbContext.Categories.Any(c => c.Name.ToLower() == updateVM.Name.ToLower() &&c.Id!=id);

            if (isExit)
            {
                ModelState.AddModelError("Name", "Bu addan artig var");
                return View();
            }
            if (existCategory == null) return NotFound();

            existCategory.Description = updateVM.Description;
            existCategory.Name = updateVM.Name;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");


        }



        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}