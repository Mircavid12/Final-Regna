using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Final.DAL;
using Final.Extentions;
using Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final.Areas.AdminRegna.Controllers
{
    [Area("AdminRegna")]
    [Authorize("Admin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AboutController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Abouts.Where(a => a.IsDeleted == false).FirstOrDefault());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            About About = _db.Abouts.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (About == null) return NotFound();
            return View(About);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(About About, int? id)
        {
            About viewAbout = _db.Abouts
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            if (About.Photo != null)
            {
                if (!About.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View(viewAbout);
                }
                if (!About.Photo.MaxSize(1000))
                {
                    ModelState.AddModelError("", "Image size must be less than 1000kb");
                    return View(viewAbout);
                }

                string folder = Path.Combine("images");
                string fileName = await About.Photo.SaveImageAsync(_env.WebRootPath, folder);
                viewAbout.Image = fileName;
            }
            viewAbout.Title = About.Title;
            viewAbout.Description = About.Description;
            About.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            About About = _db.Abouts.Where(t => t.IsDeleted == false).FirstOrDefault(t => t.Id == id);
            if (About == null) return NotFound();
            return View(About);
        }
        #endregion
    }
}
