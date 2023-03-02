using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using FiorelloProject.Models;
using FiorelloProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloProject.Areas.AdminArea.Controllers
{


    [Area("AdminArea")]
    public class SliderController : Controller

    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }


        public IActionResult Index()
        {
            return View(_appDbContext.Sliders.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(SliderCreateVM sliderCreateVM)
        {

            if(sliderCreateVM.Photo==null)
            {
                ModelState.AddModelError("Photo", "Sekil yoxdu");
                return View();

            }

            if (sliderCreateVM.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Ancag Sekil");
                return View();
            }
            if (sliderCreateVM.Photo.Length/1024>500)
            {
                ModelState.AddModelError("Photo", "Olcu Boyukdu");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + sliderCreateVM.Photo.FileName;
            string fullPath = Path.Combine(_env.WebRootPath, "img", fileName);


            using(FileStream stream = new FileStream(fullPath,FileMode.Create))
            {
                sliderCreateVM.Photo.CopyTo(stream);
            }


            Slider newSlider = new();
            newSlider.ImagreUrl = fileName;
            _appDbContext.Sliders.Add(newSlider);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}