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
    public class ApplyController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ApplyController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Applies.Where(a => a.IsDeleted == false).FirstOrDefault());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Apply Apply = _db.Applies.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Apply == null) return NotFound();
            return View(Apply);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Apply Apply, int? id)
        {
            Apply viewApply = _db.Applies
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            if (Apply.Photo != null)
            {
                if (!Apply.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View(viewApply);
                }
                if (!Apply.Photo.MaxSize(250))
                {
                    ModelState.AddModelError("", "Image size must be less than 250kb");
                    return View(viewApply);
                }

                string folder = Path.Combine("images");
                string fileName = await Apply.Photo.SaveImageAsync(_env.WebRootPath, folder);
                viewApply.Image = fileName;
            }
            viewApply.FirstName = Apply.FirstName;
            viewApply.LastName = Apply.LastName;
            viewApply.Service = Apply.Service;
            viewApply.Message = Apply.Message;
            Apply.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Apply Apply = _db.Applies.Where(t => t.IsDeleted == false).FirstOrDefault(t => t.Id == id);
            if (Apply == null) return NotFound();
            return View(Apply);
        }
        #endregion
    }
}
