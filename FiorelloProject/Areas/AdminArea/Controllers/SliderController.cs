using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
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

            return Content(_env.WebRootPath);
        }
    }
}