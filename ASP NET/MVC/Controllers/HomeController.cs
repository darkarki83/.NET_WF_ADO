using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;

        private readonly MyModel _model = new MyModel("Action methods");

        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            ViewData["Name"] = "Index";
            return View();
        }

        public IActionResult Show()
        {
            ViewData["Name"] = "My Show View";
            return View();
        }
 
        public ViewResult AnotherWay1()
        {
            ViewData["Name"] = $"{_model.Name} Another Way 1";

            return View("Index");
        }

        public ViewResult AnotherWay2()
        {
            ViewData["Name"] = $"{_model.Name} Another Way 2";

            return View("~/Views/Home/Index.cshtml");
        }

        private void ServiceMetod()
        {
            ///
        }

        public string DoService()
        {
            ServiceMetod();
            return "Artem G. Krol";
        }

        public string Calc(int a = 10, int b = 5)
        {
            return $"{a} + {b} = {a + b}";
        }

        public string Avg(int a = 10, int b = 5)
        {
            return $"({a} + {b}) / {2} = {(a + b) / 2}";
        }

        public string Hello()
        {
            string name = HttpContext.Request.Query["Name"].FirstOrDefault();
            if(name == null)
            {
                name = "Unknown";
            }


            return $"Hello, {name}";
        }

        public ContentResult ContentBack()
        {
            return Content("Artem G.Krol ");
        }

        public IActionResult Check(int id = 0)
        {
            if (id < 1 || id > 10)
                return NotFound();

            return Content(id.ToString());
        }

        public IActionResult isParameter(int? id)
        {
            if(id == null)
                return NotFound();
            return Content("I am Find"); 
        }

        public FileResult DownloadJpegFile()
        {
            string filePath = Path.Combine(_env.WebRootPath, "files", "a.jpeg");

            string fileContentType = "appication/jpeg";

            string fileName = $"SampleFile ({ DateTime.Now}).jpeg";

            return PhysicalFile(filePath, fileContentType, fileName);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
