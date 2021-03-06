﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW2.Models;

namespace HW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult MyProduct(string a)
        {
            if(a == "/a.jpg")
            {
                ViewData["About"] = "black auto number one";
            }
            else if(a == "/b.jpg")
            {
                ViewData["About"] = "orange auto number two";
            }
            else if (a == "/c.jpg")
            {
                ViewData["About"] = "yellow auto number three";
            }
            ViewData["Prod"] = a;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
