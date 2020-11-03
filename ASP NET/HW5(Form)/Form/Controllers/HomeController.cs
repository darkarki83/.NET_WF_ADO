using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Form.Models;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyLogin _model = new MyLogin();

       /* public HomeController(MyLogin model)
        {
            _model = model;
        }*/

        public IActionResult Index(string login, string pass, string submit)
        {
            ViewData["login"] = login;
            ViewData["pass"] = pass;
            if (submit == "Login")
            {
                ViewData["massage"] = "You Login";
            }
            if (submit == "Registry")
            {
                ViewData["massage"] = "You Registry";
            }
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(_model);
        }

        public IActionResult Registry()
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
