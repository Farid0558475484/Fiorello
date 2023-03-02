using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloProject.Areas.AdminArea.Controllers
{


    [Area("AdminArea")]
    public class SliderController : Controller

    {
        private readonly AppDbContext _appDbContext;

        public SliderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            return View(_appDbContext.Sliders.ToList());
        }
    }
}