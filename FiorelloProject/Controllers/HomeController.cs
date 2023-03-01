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
 

    public HomeController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

 
    }

    public IActionResult Index()
    {
        //List<Student>students= _appDbContext.Students.ToList();


        HomeVM homeVM = new HomeVM();
        homeVM.Sliders = _appDbContext.Sliders.ToList();
        homeVM.SliderDetails = _appDbContext.SliderDetails.FirstOrDefault();


        homeVM.Categories = _appDbContext.Categories.ToList();
        homeVM.Products = _appDbContext.Products.Include(m=>m.ProductImages).ToList();
        return View(homeVM);
    }

  
}

