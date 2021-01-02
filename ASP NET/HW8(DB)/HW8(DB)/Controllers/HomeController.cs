using HW8_DB_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

       [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            var courseToUpdate = await _context.Products.FindAsync(product.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                 courseToUpdate,
                 "",   // Prefix for form value.
                   c => c.Name, c => c.Cost, c => c.Description, c => c.Date))
            {
                courseToUpdate.Name = product.Name;
                courseToUpdate.Cost = product.Cost;
                courseToUpdate.Description = product.Description;
                courseToUpdate.Date = product.Date;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductView));
            }

            return View();
            
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

        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            var courseToUpdate = await _context.Users.FindAsync(user.Id);

            if(courseToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<User>(
                courseToUpdate,
                "",
                c=> c.Name, c => c.LastName, c => c.Email, c => c.DateOfReg 
                ))
            {
                courseToUpdate.Name = user.Name;
                courseToUpdate.LastName = user.LastName;
                courseToUpdate.Email = user.Email;
                courseToUpdate.DateOfReg = user.DateOfReg;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UsersView));
            }
            return View();
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

        public async Task<IActionResult> EditOrder(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(Order order)
        {
            if(order == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Orders.FindAsync(order.Id);


            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Order>(
                courseToUpdate,
                "",
                c => c.ProductFk, c => c.UserFk, c => c.Count, c => c.Date
                ))
            {
                courseToUpdate.ProductFk = order.ProductFk;
                courseToUpdate.UserFk = order.UserFk;
                courseToUpdate.Count = order.Count;
                courseToUpdate.Date = order.Date;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(OrdersView));
            }
            return View();
        }

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            var order = await _context.Orders
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                return View("DeleteOrder", order);
                
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteOrder")]
        public async Task<IActionResult> DeleteRecord(int? id)
        {

            var order = await _context.Orders
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("OrdersView");
        }

        public IActionResult SalesPeriod()
        {
            return View("Sales/SalesPeriod");
        }
        
        [HttpPost]
        [ActionName("SalesPeriod")]
        public async Task<IActionResult> SalesPeriodOut(DateTime from, DateTime to)
        {
            List<Order> brandItems = new List<Order>();
            decimal totalCost = 0;

            await _context.Orders.ForEachAsync(order =>
            {
                if(order.Date > from && order.Date < to)
                {
                    brandItems.Add(order);
                    var product = _context.Products.AsNoTracking().FirstOrDefault(o => o.Id == order.ProductFk);

                    if (product != null)
                    {
                        totalCost += product.Cost * order.Count;
                    }
                }
            });
            ViewData["TotalCost"] = totalCost;

            return View("Sales/SalesPeriodOut", brandItems.ToList());
        }

        public async Task<IActionResult> UserOrders()
        {
            StoreModel st_model = new StoreModel();
            st_model.StoreProducts = await _context.Products.ToListAsync();
            st_model.StoreUsers = await _context.Users.ToListAsync();
            st_model.StoreOrders = await _context.Orders.ToListAsync();
            return View("UserOrders", st_model);
        }

        public async Task<JsonResult> LoadOrder(int id)
        {
            var orders = _context.Orders.Where(o => o.UserFk == id).ToList();
            List<Product> products = new List<Product>();
            if (orders.Count > 0)
            {
                foreach (var item in orders)
                {
                    var product = _context.Products.AsNoTracking().FirstOrDefault(o => o.Id == item.ProductFk);
                    products.Add(product);
                }
            }
            List<ForJson> newP = new List<ForJson>();
            for (int i = 0; i < orders.Count; i++)
            {
                newP.Add(new ForJson(orders[i].Id, products[i].Name, products[i].Cost, orders[i].Count));
            }/*
            StoreModel st_model = new StoreModel();
            st_model.StoreProducts = await _context.Products.ToListAsync();
            st_model.StoreUsers = await _context.Users.ToListAsync();
            st_model.StoreOrders = await _context.Orders.ToListAsync();

            var orders = st_model.StoreOrders.Where(o => o.UserFk == id).ToList();*/
            return Json(new SelectList(newP, "Id", "PoductsName"));
        }

        /*[HttpPost]
        [ActionName("SalesPeriod")]
        public async Task<IActionResult> SalesPeriodOut(DateTime from, DateTime to)
        {
            List<Order> brandItems = new List<Order>();
            decimal totalCost = 0;

            await _context.Orders.ForEachAsync(order =>
            {
                if (order.Date > from && order.Date < to)
                {
                    brandItems.Add(order);
                    var product = _context.Products.AsNoTracking().FirstOrDefault(o => o.Id == order.ProductFk);

                    if (product != null)
                    {
                        totalCost += product.Cost * order.Count;
                    }
                }
            });
            ViewData["TotalCost"] = totalCost;

            return View("Sales/SalesPeriodOut", brandItems.ToList());
        }*/

        /// <summary>
        /// Finish Order Controllers
        /// </summary>
        /// <returns></returns>

        //All

        public async Task<IActionResult> AllView()
        {
            StoreModel st_model = new StoreModel();
            st_model.StoreProducts = await _context.Products.ToListAsync();
            st_model.StoreUsers = await _context.Users.ToListAsync();
            st_model.StoreOrders = await _context.Orders.ToListAsync();
            return View(st_model);
        }


        // PROVERKI (POTOM)
        [HttpPost]
        public JsonResult CheckProduct()
        {
            bool result = true;  /// ставить проверку

            return Json(result);
        }

        [HttpPost]
        public JsonResult CheckUserMail()
        {
            bool result = true;  /// ставить проверку

            return Json(result);
        }

        [HttpPost]
        public JsonResult UserId()
        {
            bool result = true;  /// ставить проверку

            return Json(result);
        }

        [HttpPost]
        public JsonResult ProductId()
        {
            bool result = true;  /// ставить проверку

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
