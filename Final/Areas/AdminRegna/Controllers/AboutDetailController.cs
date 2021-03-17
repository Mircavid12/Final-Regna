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
    public class AboutDetailController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AboutDetailController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.AboutDetails.Where(a => a.IsDeleted == false).ToList());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            AboutDetail aboutDetail = _db.AboutDetails.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (aboutDetail == null) return NotFound();
            return View(aboutDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutDetail aboutDetail, int? id)
        {
            AboutDetail viewAboutdetail = _db.AboutDetails
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);


            viewAboutdetail.Title = aboutDetail.Title;
            viewAboutdetail.Icon = aboutDetail.Icon;
            viewAboutdetail.Description = aboutDetail.Description;
            aboutDetail.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            AboutDetail aboutDetail = _db.AboutDetails.Where(t => t.IsDeleted == false).FirstOrDefault(t => t.Id == id);
            if (aboutDetail == null) return NotFound();
            return View(aboutDetail);
        }
        #endregion
    }
}
