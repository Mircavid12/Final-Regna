using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.DAL;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _db;

        public TeamController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["GetDevelopers"] = searchString;
            var developerQuery = from x in _db.Developers select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                developerQuery = developerQuery.Where(x => x.Name.Contains(searchString) && x.IsDeleted == false);
                return View(await developerQuery.AsNoTracking().ToListAsync());
            }
            else
            {
                ViewBag.PageCount = Decimal.Ceiling((decimal)_db.Developers.Where(s => s.IsDeleted == false).Count() / 8);
                ViewBag.page = page;
                if (page == null)
                {
                    List<Developers> developers = _db.Developers.Where(t => t.IsDeleted == false).Take(8).ToList();
                    return View(developers);
                }
                List<Developers> developers2 = _db.Developers.Where(t => t.IsDeleted == false).Skip((int)(page - 1) * 8).Take(8).ToList();
                return View(developers2);
            }
        }
        public IActionResult TeamDetails(int? id)
        {
            if (id == null)
            {
                return View(_db.Developers.Where(t => t.IsDeleted == false).Include(sd => sd.developerDetails).FirstOrDefault());
            }


            Developers developers = _db.Developers.Where(t => t.IsDeleted == false).Include(sd => sd.developerDetails).Include(sd => sd.DeveloperSkills).ThenInclude(s => s.Skills).FirstOrDefault(t => t.Id == id);
            if (developers == null)
            {
                return NotFound();
            }
            return View(developers);
        }
    }
}
