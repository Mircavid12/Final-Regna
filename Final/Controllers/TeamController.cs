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
        public async Task<IActionResult> Index()
        {
            List<Developers> developers = _db.Developers.Where(t => t.IsDeleted == false).Include(pi => pi.developerDetails).ToList();
            return View(developers);
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
