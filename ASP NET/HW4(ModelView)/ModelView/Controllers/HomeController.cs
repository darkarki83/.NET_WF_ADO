using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelView.Models;

namespace ModelView.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Product> model = new List<Product>();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductPage()
        {
            model.Add(new Product() { Id = 1, Name = "Malboro", Price = 45, CreateDate = new DateTime(2020, 10, 31) });
            model.Add(new Product() { Id = 2, Name = "Lacky strike", Price = 40, CreateDate = new DateTime(2020, 10, 31) });
            model.Add(new Product() { Id = 3, Name = "Nasha marka", Price = 22, CreateDate = new DateTime(2020, 10, 31) });
            return View(model);
        }

        public IActionResult Partial()
        {
            model.Add(new Product() { Id = 1, Name = "Malboro", Price = 45, CreateDate = new DateTime(2020, 10, 31) });
            model.Add(new Product() { Id = 2, Name = "Lacky strike", Price = 40, CreateDate = new DateTime(2020, 10, 31) });
            model.Add(new Product() { Id = 3, Name = "Nasha marka", Price = 22, CreateDate = new DateTime(2020, 10, 31) });
            return PartialView(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
