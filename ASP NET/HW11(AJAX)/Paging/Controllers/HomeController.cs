using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paging.Models;

namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Phone> phones = new List<Phone>();

        public HomeController()
        {
            phones.Add(new Phone { Id = 1, Manufacturer = "Samsung", Model = "Samsung Galaxy S6", Price = 20000 });
            phones.Add(new Phone { Id = 2, Manufacturer = "Samsung", Model = "Samsung Galaxy S6 Edge", Price = 25000 });
            phones.Add(new Phone { Id = 3, Manufacturer = "Samsung", Model = "Samsung Galaxy Note 5", Price = 22000 });
            phones.Add(new Phone { Id = 4, Manufacturer = "LG", Model = "LG G4", Price = 17000 });
            phones.Add(new Phone { Id = 5, Manufacturer = "LG", Model = "LG V10", Price = 19000 });
            phones.Add(new Phone { Id = 6, Manufacturer = "Apple", Model = "Apple iPhone 6", Price = 28000 });
            phones.Add(new Phone { Id = 7, Manufacturer = "Apple", Model = "Apple iPhone 6 Plus", Price = 31000 });
            phones.Add(new Phone { Id = 8, Manufacturer = "Lenovo", Model = "Google Nexus", Price = 10000 });
            phones.Add(new Phone { Id = 9, Manufacturer = "Sony", Model = "Sony Xperia Z5", Price = 20000 });
            phones.Add(new Phone { Id = 10, Manufacturer = "HTC", Model = "HTC One M9", Price = 20000 });
            phones.Add(new Phone { Id = 11, Manufacturer = "HTC", Model = "HTC One S", Price = 15000 });
            phones.Add(new Phone { Id = 12, Manufacturer = "HTC", Model = "HTC One X", Price = 9000 });
            phones.Add(new Phone { Id = 13, Manufacturer = "Samsung", Model = "Samsung Galaxy S6", Price = 20000 });
            phones.Add(new Phone { Id = 14, Manufacturer = "Samsung", Model = "Samsung Galaxy S6 Edge", Price = 25000 });
            phones.Add(new Phone { Id = 15, Manufacturer = "Samsung", Model = "Samsung Galaxy Note 5", Price = 22000 });
            phones.Add(new Phone { Id = 16, Manufacturer = "LG", Model = "LG G4", Price = 17000 });
            phones.Add(new Phone { Id = 17, Manufacturer = "LG", Model = "LG V10", Price = 19000 });
            phones.Add(new Phone { Id = 18, Manufacturer = "Apple", Model = "Apple iPhone 6", Price = 28000 });
            phones.Add(new Phone { Id = 19, Manufacturer = "Apple", Model = "Apple iPhone 6 Plus", Price = 31000 });
            phones.Add(new Phone { Id = 20, Manufacturer = "Lenovo", Model = "Google Nexus", Price = 10000 });
            phones.Add(new Phone { Id = 21, Manufacturer = "Sony", Model = "Sony Xperia Z5", Price = 20000 });
            phones.Add(new Phone { Id = 22, Manufacturer = "HTC", Model = "HTC One M9", Price = 20000 });
            phones.Add(new Phone { Id = 23, Manufacturer = "HTC", Model = "HTC One S", Price = 15000 });
            phones.Add(new Phone { Id = 24, Manufacturer = "HTC", Model = "HTC One X", Price = 9000 });
            phones.Add(new Phone { Id = 25, Manufacturer = "Samsung", Model = "Samsung Galaxy S6", Price = 20000 });
            phones.Add(new Phone { Id = 26, Manufacturer = "Samsung", Model = "Samsung Galaxy S6 Edge", Price = 25000 });
            phones.Add(new Phone { Id = 27, Manufacturer = "Samsung", Model = "Samsung Galaxy Note 5", Price = 22000 });
            phones.Add(new Phone { Id = 28, Manufacturer = "LG", Model = "LG G4", Price = 17000 });
            phones.Add(new Phone { Id = 29, Manufacturer = "LG", Model = "LG V10", Price = 19000 });
            phones.Add(new Phone { Id = 30, Manufacturer = "Apple", Model = "Apple iPhone 6", Price = 28000 });
            phones.Add(new Phone { Id = 31, Manufacturer = "Apple", Model = "Apple iPhone 6 Plus", Price = 31000 });
            phones.Add(new Phone { Id = 32, Manufacturer = "Lenovo", Model = "Google Nexus", Price = 10000 });
            phones.Add(new Phone { Id = 33, Manufacturer = "Sony", Model = "Sony Xperia Z5", Price = 20000 });
            phones.Add(new Phone { Id = 34, Manufacturer = "HTC", Model = "HTC One M9", Price = 20000 });
            phones.Add(new Phone { Id = 35, Manufacturer = "HTC", Model = "HTC One S", Price = 15000 });
            phones.Add(new Phone { Id = 36, Manufacturer = "HTC", Model = "HTC One X", Price = 9000 });
            phones.Add(new Phone { Id = 37, Manufacturer = "Samsung", Model = "Samsung Galaxy S6", Price = 20000 });
            phones.Add(new Phone { Id = 38, Manufacturer = "Samsung", Model = "Samsung Galaxy S6 Edge", Price = 25000 });
            phones.Add(new Phone { Id = 39, Manufacturer = "Samsung", Model = "Samsung Galaxy Note 5", Price = 22000 });
            phones.Add(new Phone { Id = 40, Manufacturer = "LG", Model = "LG G4", Price = 17000 });
            phones.Add(new Phone { Id = 41, Manufacturer = "LG", Model = "LG V10", Price = 19000 });
            phones.Add(new Phone { Id = 42, Manufacturer = "Apple", Model = "Apple iPhone 6", Price = 28000 });
            phones.Add(new Phone { Id = 43, Manufacturer = "Apple", Model = "Apple iPhone 6 Plus", Price = 31000 });
            phones.Add(new Phone { Id = 44, Manufacturer = "Lenovo", Model = "Google Nexus", Price = 10000 });
            phones.Add(new Phone { Id = 45, Manufacturer = "Sony", Model = "Sony Xperia Z5", Price = 20000 });
            phones.Add(new Phone { Id = 46, Manufacturer = "HTC", Model = "HTC One M9", Price = 20000 });
            phones.Add(new Phone { Id = 47, Manufacturer = "HTC", Model = "HTC One S", Price = 15000 });
            phones.Add(new Phone { Id = 48, Manufacturer = "HTC", Model = "HTC One X", Price = 9000 });
            phones.Add(new Phone { Id = 49, Manufacturer = "Samsung", Model = "Samsung Galaxy S6", Price = 20000 });
            phones.Add(new Phone { Id = 50, Manufacturer = "Samsung", Model = "Samsung Galaxy S6 Edge", Price = 25000 });
            phones.Add(new Phone { Id = 51, Manufacturer = "Samsung", Model = "Samsung Galaxy Note 5", Price = 22000 });
            phones.Add(new Phone { Id = 52, Manufacturer = "LG", Model = "LG G4", Price = 17000 });
            phones.Add(new Phone { Id = 53, Manufacturer = "LG", Model = "LG V10", Price = 19000 });
            phones.Add(new Phone { Id = 54, Manufacturer = "Apple", Model = "Apple iPhone 6", Price = 28000 });
            phones.Add(new Phone { Id = 55, Manufacturer = "Apple", Model = "Apple iPhone 6 Plus", Price = 31000 });
            phones.Add(new Phone { Id = 56, Manufacturer = "Lenovo", Model = "Google Nexus", Price = 10000 });
            phones.Add(new Phone { Id = 57, Manufacturer = "Sony", Model = "Sony Xperia Z5", Price = 20000 });
            phones.Add(new Phone { Id = 58, Manufacturer = "HTC", Model = "HTC One M9", Price = 20000 });
            phones.Add(new Phone { Id = 59, Manufacturer = "HTC", Model = "HTC One S", Price = 15000 });
            phones.Add(new Phone { Id = 60, Manufacturer = "HTC", Model = "HTC One X", Price = 9000 });
            phones.Add(new Phone { Id = 61, Manufacturer = "Samsung", Model = "Samsung Galaxy S6", Price = 20000 });
            phones.Add(new Phone { Id = 62, Manufacturer = "Samsung", Model = "Samsung Galaxy S6 Edge", Price = 25000 });
            phones.Add(new Phone { Id = 63, Manufacturer = "Samsung", Model = "Samsung Galaxy Note 5", Price = 22000 });
            phones.Add(new Phone { Id = 64, Manufacturer = "LG", Model = "LG G4", Price = 17000 });
            phones.Add(new Phone { Id = 65, Manufacturer = "LG", Model = "LG V10", Price = 19000 });
            phones.Add(new Phone { Id = 66, Manufacturer = "Apple", Model = "Apple iPhone 6", Price = 28000 });
            phones.Add(new Phone { Id = 67, Manufacturer = "Apple", Model = "Apple iPhone 6 Plus", Price = 31000 });
            phones.Add(new Phone { Id = 68, Manufacturer = "Lenovo", Model = "Google Nexus", Price = 10000 });
            phones.Add(new Phone { Id = 69, Manufacturer = "Sony", Model = "Sony Xperia Z5", Price = 20000 });
            phones.Add(new Phone { Id = 70, Manufacturer = "HTC", Model = "HTC One M9", Price = 20000 });
            phones.Add(new Phone { Id = 71, Manufacturer = "HTC", Model = "HTC One S", Price = 15000 });
            phones.Add(new Phone { Id = 72, Manufacturer = "HTC", Model = "HTC One X", Price = 9000 });
        }

        public ActionResult Index(int page = 1)
        {
            // Информация о страницах
            var pages = new Pages
            {
                TotalItems = phones.Count,
                PageSize = 5,                // Количество объектов на страницу
                CurrentPage = page
            };

            // Выбираем Pages.PageSize объектов для страницы page
            IEnumerable<Phone> phonesPerThisPage = phones.Skip((page - 1) * pages.PageSize).Take(pages.PageSize);

            var indexViewModel = new IndexViewModel
            {
                Pages = pages,
                Phones = phonesPerThisPage
            };
            return View(indexViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
