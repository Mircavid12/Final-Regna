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
    public class DeveloperController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public DeveloperController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Developers.Where(d=>d.IsDeleted==false).ToList());
        }
        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Developers Developers)
        {
            //if (!ModelState.IsValid)
            //{
            //    return NotFound();
            //}
            bool IsExist = _db.Developers.Where(t => t.IsDeleted == false).Any(td => td.Name.ToLower() == Developers.Name.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Title", "This Developer is already exist");
                return View();
            }
            if (Developers.Photo == null)
            {
                ModelState.AddModelError("", "Please add image");
                return View();
            }
            if (!Developers.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!Developers.Photo.MaxSize(250))
            {
                ModelState.AddModelError("", "Image size must be less than 250kb");
                return View();
            }
            string folder = Path.Combine("images", "team");
            string fileName = await Developers.Photo.SaveImageAsync(_env.WebRootPath, folder);
            Developers.Image = fileName;
            Developers.IsDeleted = false;

            await _db.Developers.AddAsync(Developers);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Developers Developers = _db.Developers.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Developers == null) return NotFound();
            return View(Developers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteDeveloper(int? id)
        {
            if (id == null) return NotFound();
            Developers Developers = _db.Developers.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Developers == null) return NotFound();
            Developers.IsDeleted = true;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Developers Developers = _db.Developers.Include(t => t.developerDetails).Include(ts => ts.DeveloperSkills).FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Developers == null) return NotFound();
            return View(Developers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Developers Developers, int? id)
        {
            Developers viewDeveloper = _db.Developers.Include(td => td.developerDetails).Include(ts => ts.DeveloperSkills)
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            if (Developers.Photo != null)
            {
                if (!Developers.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View(viewDeveloper);
                }
                if (!Developers.Photo.MaxSize(250))
                {
                    ModelState.AddModelError("", "Image size must be less than 250kb");
                    return View(viewDeveloper);
                }

                string folder = Path.Combine("images", "team");
                string fileName = await Developers.Photo.SaveImageAsync(_env.WebRootPath, folder);
                viewDeveloper.Image = fileName;
            }
            viewDeveloper.Name = Developers.Name;
            Developers.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Developers developers = _db.Developers.Where(t => t.IsDeleted == false).Include(t => t.developerDetails).Include(ts => ts.DeveloperSkills).FirstOrDefault(t => t.Id == id);
            if (developers == null) return NotFound();
            return View(developers);
        }
        #endregion
    }
}
