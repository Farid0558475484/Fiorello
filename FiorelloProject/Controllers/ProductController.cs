using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProject.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            ViewBag.ProductCount = _appDbContext.Products.Count();
            var products = _appDbContext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Take(4)
                .ToList();

            return View(products);
        }



        public IActionResult LoadMore(int skip)
        {

            var products = _appDbContext.Products
                .Include(p=>p.Category)
                .Include(P=>P.ProductImages)
                .Skip(skip)
                .Take(4)
                .ToList();

            return PartialView("_ProductLoadMorePartial",products);
        }
    }
}