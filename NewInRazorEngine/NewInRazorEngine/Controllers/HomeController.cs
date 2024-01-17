﻿using Microsoft.AspNetCore.Mvc;
using NewInRazorEngine.Models;
using System.Diagnostics;

namespace NewInRazorEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = new List<Product>()
            {
                new(){ Id =1, Name="A", Price=100},
                new(){ Id =2, Name="B", Price=100},
                new(){ Id =3, Name="C", Price=100},

            };

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}