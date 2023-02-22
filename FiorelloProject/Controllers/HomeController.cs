using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiorelloProject.Models;

namespace FiorelloProject.Controllers;

public class HomeController : Controller
{
   

    public IActionResult Index()
    {
        return View();
    }

  
}

