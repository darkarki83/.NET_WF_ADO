using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Validate.Models;

namespace Validate.Controllers
{
    public class HomeController : Controller
    {
        private readonly Order order;

        public HomeController()
        {
            order = new Order()
            {
                Name = "Komputer",
                Address = "Ole Gardom 25/1",
                Email = "Artem_krol@hotmail.com",
                Date = new DateTime(2010, 10, 12),
                TermsAccepted = "Komp"
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Input()
        {
            return View(order);
        }

        [HttpPost]
        public IActionResult Input(Order _order)
        {
            if(ModelState.IsValid)
                return View("OrderDone", order);
            else
                return View(order);
        }

        public IActionResult OrderDone()
        {
            ViewData["confirm"] = "It is Done";
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
