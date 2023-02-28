using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.Models;
using FiorelloProject.DAL;
using FiorelloProject.Migrations;
using FiorelloProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using FiorelloProject.Services.Basket;

namespace FiorelloProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _appDbContext;
    private readonly IBasketProductCount _basketProductCount;

    public HomeController(AppDbContext appDbContext, IBasketProductCount basketProductCount)
    {
        _appDbContext = appDbContext;
        _basketProductCount = basketProductCount;
    }

    public IActionResult Index()
    {
        //List<Student>students= _appDbContext.Students.ToList();

        int result = _basketProductCount.CalculateBasketProductCount();
        HomeVM homeVM = new HomeVM();
        homeVM.Sliders = _appDbContext.Sliders.ToList();
        homeVM.SliderDetails = _appDbContext.SliderDetails.FirstOrDefault();


        homeVM.Categories = _appDbContext.Categories.ToList();
        homeVM.Products = _appDbContext.Products.Include(m=>m.ProductImages).ToList();
        return View(homeVM);
    }

  
}

