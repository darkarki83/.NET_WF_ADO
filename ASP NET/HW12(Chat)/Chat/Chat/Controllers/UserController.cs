using Chat.Models;
using Chat.Models.Contaxt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    public class UserController : Controller
    {
        private ChatDbContext _context;

        //private DbSet<User> _contextUser
        //private DbSet<Role> _contextRoles

        public UserController(ChatDbContext context)
        {
            _context = context;

            //_contextRole = context.Roles;
            //_contextUser = context.User;
        }

        // GET: UserController
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListUsers()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // GET: UserController/Create
        [ActionName("Register")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ActionName("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Register register)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == register.Email);
                
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = register.Email, Password = register.Password, Name = register.Name};
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "User");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(register);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            var courseToUpdate = await _context.Users.FindAsync(user.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                courseToUpdate,
                "",
                l => l.Email, l => l.Password, l => l.Name
                ))
            {
                courseToUpdate.Email = user.Name;
                courseToUpdate.Password = user.Password;
                courseToUpdate.Name = user.Name;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListUsers));
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditRole()
        {
            ViewBag.Names = _context.Users;
            ViewBag.Roles = _context.Roles;

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(long? id, long? roleFk)
        {
            if (id == null || roleFk == null)
                return NotFound();

            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            var courseToUpdate = await _context.Users.FindAsync(user.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
            courseToUpdate,
            "",
            s => s.RoleFk
            ))
            {
                courseToUpdate.RoleFk = roleFk;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListUsers));
            }

            return View();
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                return View("Delete", user);

            }
            return RedirectToAction(nameof(ListUsers));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ActionName("delete")]
        public async Task<ActionResult> Delete(User deluser)
        {
            var user = await _context.Users
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == deluser.Id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListUsers));
        }

        //login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        //Roles
        //[Authorize(Roles = "admin, lector")]   на посмотреть
        public async Task<IActionResult> ListRoles()
        {
            return View(await _context.Roles.ToListAsync());
        }

        //[Authorize(Roles = "admin")]   на крайний случай
        /* public IActionResult CreateRole()
         {
             return View();
         }

         //[Authorize(Roles = "admin")]
         [HttpPost]
         public async Task<IActionResult> CreateRole(Role role)
         {
             if (ModelState.IsValid)
             {
                 await _context.Roles.AddAsync(role);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(ListRoles));
             }
             else
             {
                 return View(role);
             }
         }
        */
    }
}
