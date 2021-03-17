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
using Microsoft.AspNetCore.Http;
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
            if (Portfolio.Photos == null)
            {
                ModelState.AddModelError("", "Please add image");
                return View();
            }
            List<PortfolioImages> portfolioImages = new List<PortfolioImages>();
            foreach (IFormFile photo in Portfolio.Photos)
            {
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View();
                }
                if (!photo.MaxSize(1200))
                {
                    ModelState.AddModelError("", "Image size must be less than 1200kb");
                    return View();
                }
                string folder = Path.Combine("images", "portfolio");
                string fileName = await photo.SaveImageAsync(_env.WebRootPath, folder);
                PortfolioImages pi = new PortfolioImages { Name = fileName, PortfolioId=Portfolio.Id};
                portfolioImages.Add(pi);
            }

            Portfolio.PortfolioImages = portfolioImages;

            
            

            Portfolio.IsDeleted = false;

            await _db.Portfolios.AddAsync(Portfolio);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Portfolio Portfolio = _db.Portfolios.Where(p => p.IsDeleted == false).Include(pd => pd.PortfolioDetails).Include(p=>p.PortfolioImages).FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Portfolio == null) return NotFound();
            return View(Portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePortfolio(int? id)
        {
            if (id == null) return NotFound();
            Portfolio Portfolio = _db.Portfolios.Where(p=>p.IsDeleted==false).Include(pd=>pd.PortfolioDetails).Include(p => p.PortfolioImages).FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Portfolio == null) return NotFound();
            Portfolio.IsDeleted = true;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Portfolio Portfolio = _db.Portfolios.Include(t => t.PortfolioDetails).FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Portfolio == null) return NotFound();
            return View(Portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Portfolio Portfolio, int? id)
        {
            Portfolio viewPortfolio = _db.Portfolios.Include(td => td.PortfolioDetails)
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            viewPortfolio.Name = Portfolio.Name;
            Portfolio.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            GetDevelopers();
            if (id == null) return NotFound();
            Portfolio Portfolio = _db.Portfolios.Where(t => t.IsDeleted == false).Include(t => t.PortfolioDetails).Include(p=>p.PortfolioImages).Include(p=>p.PortfolioDevelopers).ThenInclude(p=>p.Developers).FirstOrDefault(t => t.Id == id);
            if (Portfolio == null) return NotFound();
            return View(Portfolio);
        }
        #endregion

        private void GetDevelopers()
        {
            ViewBag.GetDeveloper = _db.Developers.Where(d => d.IsDeleted == false).ToList();
            ViewBag.GetServices = _db.Services.Where(d => d.IsDeleted == false).ToList();
        }
    }
}
