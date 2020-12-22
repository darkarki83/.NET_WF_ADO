using HW8_DB_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HW8_DB_.Controllers
{
    public class HomeController : Controller
    {
        private StoreDBContext _context;

        public HomeController(StoreDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Product
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Date = DateTime.Now;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductView));
            }
            else
                return View(product);
            
        }

        public async Task<IActionResult> ProductView()
        {
            return View(await _context.Products.ToListAsync());
        }
        /// <summary>
        /// Finish Product Controllers
        /// </summary>
        /// <returns></returns>

        //User

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UsersView));

            }
            else
            {
                return View(user);
            }
        }

        public async Task<IActionResult> UsersView()
        {
            return View(await _context.Users.ToListAsync());
        }

        /// <summary>
        /// Finish User Controllers
        /// </summary>
        /// <returns></returns>

        //Order

        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Date = DateTime.Now;
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(OrdersView));

            }
            else
            {
                return View(order);
            }
        }

        public async Task<IActionResult> OrdersView()
        {
            return View(await _context.Orders.ToListAsync());
        }

        /// <summary>
        /// Finish Order Controllers
        /// </summary>
        /// <returns></returns>



        // PROVERKI (POTOM)
        public IActionResult CheckProduct()
        {
            return View();
        }

        public IActionResult CheckUserMail()
        {
            return View();
        }

        public IActionResult UserId()
        {
            return View();
        }

        public IActionResult ProductId()
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
