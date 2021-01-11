using HW9.Models;
using HW9.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Controllers
{
    public class HomeController : Controller
    {
        private JurnalDbContext _context;

        public HomeController(JurnalDbContext context)
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

        //Student
        public async Task<IActionResult> ListStudent()
        {
            return View(await _context.Students.ToListAsync());
        }

        public async Task<IActionResult> DetailsStudent(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.AsNoTracking().SingleOrDefaultAsync( s => s.Id == id );

            return View(student);
        }

        public IActionResult CreateStudent()
        {
            return View();   
        }

        [HttpPost]
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
        }

        // Subject

        public async Task<IActionResult> ListSubject()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        public async Task<IActionResult> DetailsSubject(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

            return View(subject);
        }

        public IActionResult CreateSubject()
        {
            ViewBag.lecturer = _context.Lecturers;

            //ViewBag.lecturer = new SelectList(_context.Lecturers, "Id", "Name");

            return View();
        }

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

        public async Task<IActionResult> EditSubject(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
            if (subject == null)
                return NotFound();

            ViewBag.lecturer = _context.Lecturers;
            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubject(Subject subject)
        {
            var courseToUpdate = await _context.Subjects.FindAsync(subject.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Subject>(
                courseToUpdate,
                "",
                s => s.Name, s => s.Faciltet, s => s.LecturerFk
                ))
            {
                courseToUpdate.Name = subject.Name;
                courseToUpdate.Faciltet = subject.Faciltet;
                courseToUpdate.LecturerFk = subject.LecturerFk;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSubject));
            }
            return View();
        }

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
        public async Task<IActionResult> ListAppraisal()
        {
            return View(await _context.Appraisals.ToListAsync());
        }

        public async Task<IActionResult> DetailsAppraisal(int? id)
        {
            if (id == null)
                return NotFound();

            var appraisal = await _context.Appraisals.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

            return View(appraisal);
        }

        public IActionResult CreateAppraisal()
        {
            ViewBag.Student = _context.Students;
            //ViewBag.lecturer = new SelectList(_context.Lecturers, "Id", "Name");
            ViewBag.Subject = _context.Subjects;
            return View();
        }

        [HttpPost]
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

        public async Task<IActionResult> EditAppraisal(int? id)
        {
            if (id == null)
                return NotFound();

            var appraisal = await _context.Appraisals.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
            if (appraisal == null)
                return NotFound();

            ViewBag.Student = _context.Students;
            ViewBag.Subject = _context.Subjects;
            return View(appraisal);
        }

        [HttpPost]
        public async Task<IActionResult> EditAppraisal(Appraisal appraisal)
        {
            var courseToUpdate = await _context.Appraisals.FindAsync(appraisal.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Appraisal>(
                courseToUpdate,
                "",
                a => a.Rating, a => a.StudentFk, a => a.SubjectFk
                ))
            {
                courseToUpdate.Rating = appraisal.Rating;
                courseToUpdate.StudentFk = appraisal.StudentFk;
                courseToUpdate.SubjectFk = appraisal.SubjectFk;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAppraisal));
            }
            return View();
        }

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
        public async Task<JsonResult> CheckUserMail(string MyEmail)
        {
            var email = await _context.Students.Where(o => o.Email == MyEmail).FirstOrDefaultAsync();
            bool result = true;
            if (email != null)
                result = true;  /// ставить проверку
            else
                result = false;  /// ставить проверку

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
