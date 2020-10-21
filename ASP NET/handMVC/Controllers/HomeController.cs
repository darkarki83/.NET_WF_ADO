using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace handMVC.Controllers
{
    public class HomeController : Controller
    {


            public IActionResult Index()
            {
                ViewBag.Privet = "Privat";
                return View();
            }

            public IActionResult Show()
            {
                ViewBag.Hiiii = "Hiiii";
                return View();
            }
    }
}