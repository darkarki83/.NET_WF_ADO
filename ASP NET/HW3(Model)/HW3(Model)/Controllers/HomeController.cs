using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW3_Model_.Models;

namespace HW3_Model_.Controllers
{
    public class HomeController : Controller
    {
        private readonly Adress adress =  new Adress("tel aviv", "ole gardom", 12, 25);

        private readonly Order order = new Order("Shoshanim", 25, "I love You", "Eyal" 
            , new DateTime(2020, 11, 02), new Adress("tel aviv", "ole gardom", 12, 25));
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YourOrder()
        {
            return View(order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
