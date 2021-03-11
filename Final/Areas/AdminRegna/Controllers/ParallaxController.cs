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

namespace Final.Areas.AdminRegna.Controllers
{
    [Area("AdminRegna")]
    [Authorize("Admin")]
    public class ParallaxController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ParallaxController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Parallaxes.Where(a => a.IsDeleted == false).FirstOrDefault());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Parallax Parallax = _db.Parallaxes.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Parallax == null) return NotFound();
            return View(Parallax);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Parallax Parallax, int? id)
        {
            Parallax viewParallax = _db.Parallaxes
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            if (Parallax.Photo != null)
            {
                if (!Parallax.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View(viewParallax);
                }
                if (!Parallax.Photo.MaxSize(250))
                {
                    ModelState.AddModelError("", "Image size must be less than 250kb");
                    return View(viewParallax);
                }

                string folder = Path.Combine("images");
                string fileName = await Parallax.Photo.SaveImageAsync(_env.WebRootPath, folder);
                viewParallax.Image = fileName;
            }
            viewParallax.Title = Parallax.Title;
            viewParallax.Description = Parallax.Description;
            Parallax.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Parallax Parallax = _db.Parallaxes.Where(t => t.IsDeleted == false).FirstOrDefault(t => t.Id == id);
            if (Parallax == null) return NotFound();
            return View(Parallax);
        }
        #endregion
    }
}
