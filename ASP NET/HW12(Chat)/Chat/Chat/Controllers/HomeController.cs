using Chat.Models;
using Chat.Models.Contaxt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private ChatDbContext _context;

        public HomeController(ChatDbContext context)
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

        // Section
        public async Task<IActionResult> ListSections()
        {
            return View(await _context.Sections.ToListAsync());
        }

        public async Task<IActionResult> DetailsSection(int? id)
        {
            var sections = await _context.Sections.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (sections == null)
                return NotFound();

            return View(sections);
        }

        public IActionResult CreateSection()
        {
            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if (item.RoleFk > 2)
                    users.Add(item);
            }
            ViewBag.OpenUser = users;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSection(Section section)
        {
            if (ModelState.IsValid)
            {
                await _context.Sections.AddAsync(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSections));
            }
            else
                return View(section);
        }

        public async Task<IActionResult> EditSection(int? id)
        {
            var section = await _context.Sections.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            
            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if (item.RoleFk > 2)
                    users.Add(item);
            }
            ViewBag.OpenUser = users;

            if (section == null)
                return NotFound();

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSection(Section section)
        {
            var courseToUpdate = await _context.Sections.FindAsync(section.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Section>(
                courseToUpdate,
                "",
                s => s.Name, s => s.OpenUser
                ))
            {
                courseToUpdate.Name = section.Name;
                courseToUpdate.OpenUser = section.OpenUser;
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSections));
            }
            return View();
        }

        public async Task<ActionResult> DeleteSection(int? id)
        {
            if (id == null)
                return NotFound();

            var section = await _context.Sections
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (section != null)
            {
                return View("DeleteSection", section);

            }
            return RedirectToAction(nameof(ListSections));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSection(Section delSection)
        {
            ///  add cascade delite
            ///
            ///
            var section = await _context.Sections
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Id == delSection.Id);

            if (section != null)
            {
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListSections));
        }

        //Theme
        public async Task<IActionResult> ListThemes()
        {
            return View(await _context.Themes.ToListAsync());
        }

        public async Task<IActionResult> DetailsTheme(int? id)
        {
            var theme = await _context.Themes.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (theme == null)
                return NotFound();

            return View(theme);
        }

        public IActionResult CreateTheme()
        {
            ViewBag.SectionFk = _context.Sections;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheme(Theme theme)
        {
            if (ModelState.IsValid)
            {
                theme.DateOpen = DateTime.Now;
                await _context.Themes.AddAsync(theme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListThemes));
            }
            else
                return View(theme);
        }

        public async Task<IActionResult> AddModeratorToTheme(int? id)
        {
            var theme = await _context.Themes.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (theme == null)
                return NotFound();

            List<User> users = new List<User>();
            foreach (var item in _context.Users)
            {
                if (item.RoleFk == 3)
                    users.Add(item);
            }
            ViewBag.ModeratorUser = users;

            return View(theme);
        }

        [HttpPost]
        public async Task<IActionResult> AddModeratorToTheme(long? id, long? ModeratorUser)
        {
            if (id == null || ModeratorUser == null)
                return NotFound();

            var theme = await _context.Themes.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            if (theme == null)
                return NotFound();

            var courseToUpdate = await _context.Themes.FindAsync(theme.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Theme>(
            courseToUpdate,
            "",
            t => t.ModeratorUser
            ))
            {
                courseToUpdate.ModeratorUser = ModeratorUser;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListThemes));
            }

            return View();
        }

        public async Task<IActionResult> EditTheme(int? id)
        {
            var theme = await _context.Themes.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

            if (theme == null)
                return NotFound();

            ViewBag.SectionFk = _context.Sections;

            return View(theme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTheme(Theme theme)
        {
            var courseToUpdate = await _context.Themes.FindAsync(theme.Id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Theme>(
                courseToUpdate,
                "",
                t => t.Name, t => t.SectionFk
                ))
            {
                courseToUpdate.Name = theme.Name;
                courseToUpdate.SectionFk = theme.SectionFk;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListThemes));
            }
            return View();
        }

        public async Task<ActionResult> DeleteTheme(int? id)
        {
            if (id == null)
                return NotFound();

            var theme = await _context.Themes
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (theme != null)
            {
                return View("DeleteTheme", theme);

            }
            return RedirectToAction(nameof(ListThemes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTheme(Theme delTheme)
        {
            ///  add cascade delite
            ///
            ///
            var theme = await _context.Themes
               .AsNoTracking()
               .FirstOrDefaultAsync(t => t.Id == delTheme.Id);

            if (theme != null)
            {
                _context.Themes.Remove(theme);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListThemes));
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
