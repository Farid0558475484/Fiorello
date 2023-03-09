using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using FiorelloProject.Extensions;
using FiorelloProject.Helpers;
using FiorelloProject.Models;
//using FiorelloProject.Migrations;
using FiorelloProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    //[Authorize]
    public class ProductController : Controller
    {


        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index(int page=1, int take=2)
        {

            var products = _appDbContext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Skip((page-1)*take)
                .Take(take)
                .ToList();
            int pageCount = CalculatePageCount(_appDbContext.Products.ToList(), take);
            PaginationVM<Product> pagination = new(products, pageCount,page);

            return View(pagination);
        }


        private int CalculatePageCount(List<Product>products , int take)
        {
            return (int)Math.Ceiling((decimal)(products.Count) / take);
        }

 

        public IActionResult Create()
        {

            //ViewBag.Categories = _appDbContext.Categories.ToList();
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {

    
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();

            List<ProductImage> productImages = new();

            foreach (var photo in productCreateVM.Photos)
            {

        

                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photos", "Ancag Sekil");
                    return View();
                }


                if (photo.CheckImageSize(500))
                {
                    ModelState.AddModelError("Photos", "Olcu Boyukdu");
                    return View();
                }


                ProductImage productImage = new();
                productImage.ImageUrl = photo.SaveImage(_env, "img", photo.FileName);
                productImages.Add(productImage);
            }

            Product newproduct = new();
            newproduct.Name = productCreateVM.Name;
            newproduct.Price = productCreateVM.Price;
            newproduct.CategoryId = productCreateVM.CategoryId;
            newproduct.ProductImages = productImages;

            _appDbContext.Products.Add(newproduct);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}