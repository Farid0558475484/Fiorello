using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using FiorelloProject.Models;
using FiorelloProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FiorelloProject.Controllers
{
    public class BasketController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public BasketController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {

            //HttpContext.Session.SetString("name","Farid");
            Response.Cookies.Append("name", "farid", new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            return Content("set olundu");
        }



        public async Task<IActionResult> Add(int id, string name)
        {

            if (id == null) return NotFound();

            Product product = await _appDbContext.Products.FindAsync(id);

            if (product == null) return NotFound();
            List<BasketVM> products;


            if (Request.Cookies["basket"] == null)
            {
                products = new();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }

            BasketVM existproduct= products.FirstOrDefault(p => p.Id == id);
            if(existproduct ==null)
            {
                BasketVM basketVM = new();
                basketVM.Id = product.Id;
        
                basketVM.BasketCount = 1;
                basketVM.ImageUrl = product.ProductImages.FirstOrDefault().ImageUrl;
                products.Add(basketVM);

            }
            else
            {
                existproduct.BasketCount++;

            }


            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions
            { MaxAge = TimeSpan.FromHours(1) });



            return RedirectToAction(nameof(Index), "Home");
        }






        public IActionResult ShowBasket()
        {
            List<BasketVM> products;
            string basket = Request.Cookies["basket"];
            if(basket==null)
            {
                products = new();
            }
            else
            {
               products= JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product currentproduct = _appDbContext
                        .Products
                        .Include(p => p.ProductImages)
                        .FirstOrDefault(p => p.Id == item.Id);
                    item.Name = currentproduct.Name;
                    item.Price = currentproduct.Price;
                    item.Id = currentproduct.Id;
                    item.ImageUrl = currentproduct.ProductImages.FirstOrDefault().ImageUrl;

                }
            }
     
            return View(products);
        }

    }
}