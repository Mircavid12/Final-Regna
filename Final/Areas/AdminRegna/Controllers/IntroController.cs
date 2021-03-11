using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.DAL;
using Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Final.Areas.AdminRegna.Controllers
{
    [Area("AdminRegna")]
    [Authorize("Admin")]
    public class IntroController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public IntroController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Intros.Where(i => i.IsDeleted == false).FirstOrDefault());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Intro intro = _db.Intros.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (intro == null) return NotFound();
            return View(intro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Intro intro, int? id)
        {
            Intro viewIntro = _db.Intros
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);


            viewIntro.Title = intro.Title;
            intro.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
