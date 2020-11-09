using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountContext context_model;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AccountContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            context_model = context;
        }

        public async Task<IActionResult> AllUsers()
        {
            return View(await context_model.Accounts.ToListAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            if (ModelState.IsValid)
            {
                return View("Login");
            }
            else
            {
                context_model.Accounts.Add(account);

                await context_model.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult About()
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
