using HW9.Filters;
using HW9.Models;
using HW9.Models.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HW9.Controllers
{
    [CustomActionAttribute]
    public class HomeController : Controller
    {
        private JurnalDbContext _context;

        public HomeController(JurnalDbContext context)
        {
            _context = context;
        }

        //[Authorize(Roles = "admin")]
        public IActionResult About()
        {
            return Content("Вход только для администратора");
        }

        //[Authorize(Roles = "admin, lector, student")]
        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            //return Content($"ваша роль: {role}");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Password = model.Password, Name = model.Name, Age = model.Age };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация


                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    //string role = user.Role.Name;
                    //return Content($"ваша роль: {role}");
                    return RedirectToAction("Index", "Home");
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

            // ViewData["Name"] = user.Email;
            // ViewData["Role"] = user.Role;
        }

        //Roles
        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> ListRoles()
        {
            return View(await _context.Roles.ToListAsync());
        }

        [Authorize(Roles = "admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
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

        //user
        //only for look (for me)
        [Authorize(Roles = "admin, lector, user")]
        public async Task<IActionResult> ListUsers()
        {
            return View(await _context.Users.ToListAsync());
        }

        [Authorize(Roles = "admin, lector, user")]
        public async Task<IActionResult> DetailsUser(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

            return View(user);
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [Authorize(Roles = "admin, lector")]
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            var courseToUpdate = await _context.Users.FindAsync(user.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                courseToUpdate,
                "",
                s => s.Email, s => s.Password, s => s.Name, s => s.Age, s => s.RoleFk
                ))
            {
                courseToUpdate.Email = user.Email;
                courseToUpdate.Password = user.Password;
                courseToUpdate.Name = user.Name;
                courseToUpdate.Age = user.Age;
                courseToUpdate.RoleFk = user.RoleFk;


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListUsers));
            }
            return View();
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (user != null)
            {
                return View("DeleteUser", user);

            }
            return RedirectToAction(nameof(ListUsers));
        }

        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUse(int? id)
        {

            var user = await _context.Users
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListUsers));
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

        /*
        //Student
        public async Task<IActionResult> ListStudent()
        {
            return View(await _context.Students.ToListAsync());
        }

        [Authorize(Roles = "admin, lector, student")]
        public async Task<IActionResult> DetailsStudent(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.AsNoTracking().SingleOrDefaultAsync( s => s.Id == id );

            return View(student);
        }

        [Authorize(Roles = "admin, lector")]
        public IActionResult CreateStudent()
        {
            return View();   
        }


        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> CreateStudent(Student student)
        {
           if(ModelState.IsValid)
           {
               await _context.Students.AddAsync(student);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(ListStudent));
           }
           else
           {
               return View(student);
           }
        }

        public async Task<IActionResult> EditStudent(int? id)
        {
            if(id == null)
                return NotFound();

            var user = await _context.Students.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            if(user == null)
                return NotFound(); 

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            var courseToUpdate = await _context.Students.FindAsync(student.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
                courseToUpdate,
                "",
                s => s.Name, s => s.LastName, s => s.Age, s => s.DateOfReg, s => s.Email
                ))
            {
                courseToUpdate.Name = student.Name;
                courseToUpdate.LastName = student.LastName;
                courseToUpdate.Age = student.Age;
                courseToUpdate.DateOfReg = student.DateOfReg;
                courseToUpdate.Email = student.Email;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListStudent));
            }
            return View();
        }

        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if(id == null)
                return NotFound();

            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            
            if (student != null)
            {
                return View("DeleteStudent", student);

            }
            return RedirectToAction(nameof(ListStudent));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteStudent")]
        public async Task<IActionResult> DeleteRecord(int? id)
        {

            var student = await _context.Students
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListStudent));
        }

        // Lecturer

        public async Task<IActionResult> ListLecturer()
        {
            return View(await _context.Lecturers.ToListAsync());
        }

        public async Task<IActionResult> DetailsLecturer(int? id)
        {
            if (id == null)
                return NotFound();

            var lecturer = await _context.Lecturers.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

            return View(lecturer);
        }

        public IActionResult CreateLecturer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLecturer(Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                await _context.Lecturers.AddAsync(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListLecturer));
            }
            else
            {
                return View(lecturer);
            }
        }

        public async Task<IActionResult> EditLecturer(int? id)
        {
            if (id == null)
                return NotFound();

            var lecturer = await _context.Lecturers.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            if (lecturer == null)
                return NotFound();

            return View(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> EditLecturer(Lecturer lecturer)
        {
            var courseToUpdate = await _context.Lecturers.FindAsync(lecturer.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Lecturer>(
                courseToUpdate,
                "",
                l => l.Name, l => l.LastName, l => l.Age, l => l.Email
                ))
            {
                courseToUpdate.Name = lecturer.Name;
                courseToUpdate.LastName = lecturer.LastName;
                courseToUpdate.Age = lecturer.Age;
                courseToUpdate.Email = lecturer.Email;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListLecturer));
            }
            return View();
        }

        public async Task<IActionResult> DeleteLecturer(int? id)
        {
            if (id == null)
                return NotFound();

            var lecturer = await _context.Lecturers
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (lecturer != null)
            {
                return View("DeleteLecturer", lecturer);

            }
            return RedirectToAction(nameof(ListLecturer));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteLecturer")]
        public async Task<IActionResult> DeleteLect(int? id)
        {

            var lecturer = await _context.Lecturers
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (lecturer != null)
            {
                _context.Lecturers.Remove(lecturer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListLecturer));
        }*/

        // Subject

        [Authorize(Roles = "admin, lector, user")]
        public async Task<IActionResult> ListSubject()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> DetailsSubject(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

            return View(subject);
        }

        [Authorize(Roles = "admin, lector")]
        public IActionResult CreateSubject()
        {
            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if(item.RoleFk == 2)
                    users.Add(item);
            }
            ViewBag.lecturer = users;

            return View();
        }

        [Authorize(Roles = "admin, lector")]
        [HttpPost]
        public async Task<IActionResult> CreateSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _context.Subjects.AddAsync(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSubject));
            }
            else
                return View(subject);
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> EditSubject(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
            if (subject == null)
                return NotFound();

            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if (item.RoleFk == 2)
                    users.Add(item);
            }
            ViewBag.lecturer = users;

            return View(subject);
        }

        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> EditSubject(Subject subject, int UserLectorFk)
        {
            var courseToUpdate = await _context.Subjects.FindAsync(subject.Id);

            if (courseToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync<Subject>(
                courseToUpdate,
                "",
                s => s.Name, s => s.Faciltet, s => s.UserLectorFk
                ))
            {
                courseToUpdate.Name = subject.Name;
                courseToUpdate.Faciltet = subject.Faciltet;
                courseToUpdate.UserLectorFk = UserLectorFk;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSubject));
            }
            return View();
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> DeleteSubject(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject != null)
            {
                return View("DeleteSubject", subject);

            }
            return RedirectToAction(nameof(ListSubject));
        }

        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteSubject")]
        public async Task<IActionResult> DeleteSub(int? id)
        {

            var subject = await _context.Subjects
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListSubject));
        }

        /// Appraisal
        /// 
        [Authorize(Roles = "admin, lector, user")]
        public async Task<IActionResult> ListAppraisal()
        {
            return View(await _context.Appraisals.ToListAsync());
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> DetailsAppraisal(int? id)
        {
            if (id == null)
                return NotFound();

            var appraisal = await _context.Appraisals.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

            return View(appraisal);
        }

        [Authorize(Roles = "admin, lector")]
        public IActionResult CreateAppraisal()
        {
            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if (item.RoleFk == 1)
                    users.Add(item);
            }
            ViewBag.Student = users;
            ViewBag.Subject = _context.Subjects;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> CreateAppraisal(Appraisal appraisal)
        {
            if (ModelState.IsValid)
            {
                await _context.Appraisals.AddAsync(appraisal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAppraisal));
            }
            else
                return View(appraisal);
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> EditAppraisal(int? id)
        {
            if (id == null)
                return NotFound();

            var appraisal = await _context.Appraisals.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
            if (appraisal == null)
                return NotFound();

            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if (item.RoleFk == 1)
                    users.Add(item);
            }
            ViewBag.Student = users;
            ViewBag.Subject = _context.Subjects;

            return View(appraisal);
        }

        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> EditAppraisal(Appraisal appraisal)
        {
            var courseToUpdate = await _context.Appraisals.FindAsync(appraisal.Id);

            if (courseToUpdate == null)
                return NotFound();
            

            if (await TryUpdateModelAsync<Appraisal>(
                courseToUpdate,
                "",
                a => a.Rating, a => a.UserStudentFk, a => a.SubjectFk
                ))
            {
                courseToUpdate.Rating = appraisal.Rating;
                courseToUpdate.UserStudentFk = appraisal.UserStudentFk;
                courseToUpdate.SubjectFk = appraisal.SubjectFk;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAppraisal));
            }
            return View();
        }

        [Authorize(Roles = "admin, lector")]
        public async Task<IActionResult> DeleteAppraisal(int? id)
        {
            if (id == null)
                return NotFound();

            var appraisal = await _context.Appraisals
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (appraisal != null)
            {
                return View("DeleteAppraisal", appraisal);

            }
            return RedirectToAction(nameof(ListAppraisal));
        }

        [HttpPost]
        [Authorize(Roles = "admin, lector")]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteAppraisal")]
        public async Task<IActionResult> DeleteApp(int? id)
        {

            var appraisal = await _context.Appraisals
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == id);

            if (appraisal != null)
            {
                _context.Appraisals.Remove(appraisal);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListAppraisal));
        }

        /// <summary>  не работает не понятно почему
        /// </summary>
        /// <param name="MyEmail"></param>
        /// <returns></returns>

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
