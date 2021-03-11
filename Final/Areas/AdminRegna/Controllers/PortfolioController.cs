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
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PortfolioController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Portfolios.Where(d => d.IsDeleted == false).ToList());
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio Portfolio)
        {
            //if (!ModelState.IsValid)
            //{
            //    return NotFound();
            //}
            bool IsExist = _db.Portfolios.Where(t => t.IsDeleted == false).Include(pd=>pd.PortfolioDetails).Include(pi=>pi.PortfolioImages).Any(td => td.Name.ToLower() == Portfolio.Name.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Title", "This Developer is already exist");
                return View();
            }
            if (Portfolio.PortfolioImages.FirstOrDefault().Photo == null)
            {
                ModelState.AddModelError("", "Please add image");
                return View();
            }
            if (!Portfolio.PortfolioImages.FirstOrDefault().Photo.IsImage())
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!Portfolio.PortfolioImages.FirstOrDefault().Photo.MaxSize(250))
            {
                ModelState.AddModelError("", "Image size must be less than 250kb");
                return View();
            }
            string folder = Path.Combine("images", "portfolio");
            string fileName = await Portfolio.PortfolioImages.FirstOrDefault().Photo.SaveImageAsync(_env.WebRootPath, folder);
            Portfolio.PortfolioImages.FirstOrDefault().Name = fileName;
            Portfolio.IsDeleted = false;

            Portfolio.IsDeleted = false;

            await _db.Portfolios.AddAsync(Portfolio);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
