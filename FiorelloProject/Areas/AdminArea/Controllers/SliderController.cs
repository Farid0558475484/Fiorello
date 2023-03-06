using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using FiorelloProject.Extensions;
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

            if (!sliderCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Ancag Sekil");
                return View();
            }


            if (sliderCreateVM.Photo.CheckImageSize(500))
            {
                ModelState.AddModelError("Photo", "Olcu Boyukdu");
                return View();
            }

            Slider newSlider = new();
            newSlider.ImagreUrl = sliderCreateVM.Photo.SaveImage(_env, "img", sliderCreateVM.Photo.FileName);

            _appDbContext.Sliders.Add(newSlider);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var slider = _appDbContext.Sliders.FirstOrDefault(a => a.Id == id);
            if (slider == null) return NotFound();
            string fullPath = Path.Combine(_env.WebRootPath, "img", slider.ImagreUrl);

            if (
            System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            _appDbContext.Remove(slider);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Slider slider = _appDbContext.Sliders.SingleOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();
            return View(new SliderUpdateVM { ImageUrl=slider.ImagreUrl});
        }



        [HttpPost]
        public IActionResult Edit(int id,SliderUpdateVM updateVM)
        {
            if (id == null) return NotFound();
            Slider slider = _appDbContext.Sliders.SingleOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();
            if(updateVM.Photo!=null)
            {
                string fullPath = Path.Combine(_env.WebRootPath, "img", slider.ImagreUrl);

                if (!updateVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Ancag Sekil");
                    return View();
                }


                if (updateVM.Photo.CheckImageSize(500))
                {
                    ModelState.AddModelError("Photo", "Olcu Boyukdu");
                    return View();
                }

                if (
                System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                slider.ImagreUrl = updateVM.Photo.SaveImage(_env, "img", updateVM.Photo.FileName);
                _appDbContext.SaveChanges();

            }


            return RedirectToAction("Index");
        }
    }
}