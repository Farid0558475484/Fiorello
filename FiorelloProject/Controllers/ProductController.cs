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

            var products = _appDbContext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .ToList();

            return View(products);
        }
    }
}