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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ServiceController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Services.Where(d => d.IsDeleted == false).ToList());
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            GetDevelopers();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Services Services, List<int> developerId)
        {
            GetDevelopers();
            //if (!ModelState.IsValid)
            //{
            //    return NotFound();
            //}
            if (developerId==null)
            {
                ModelState.AddModelError("", "Select Developers");
                return View();
            }
            //Services services = new Services();
            List<ServiceDevelopers> sd = new List<ServiceDevelopers>();
            foreach (int item in developerId)
            {
                ServiceDevelopers serviceDevelopers = new ServiceDevelopers()
                {
                    DevelopersId = item,
                    ServicesId = Services.Id,
                    Services = Services
                };
                sd.Add(serviceDevelopers);
                await _db.ServiceDevelopers.AddAsync(serviceDevelopers);
            }

            Developers developers = _db.Developers.Include(sd => sd.ServiceDevelopers).ThenInclude(s => s.Services).FirstOrDefault(d=>d.IsDeleted==false);
            bool IsExist = _db.Services.Where(t => t.IsDeleted == false).Any(td => td.Title.ToLower() == Services.Title.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Title", "This Service is already exist");
                return View();
            }
            if (Services.ServiceDetails.Photo == null)
            {
                ModelState.AddModelError("", "Please add image");
                return View();
            }
            if (!Services.ServiceDetails.Photo.IsImage())
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!Services.ServiceDetails.Photo.MaxSize(250))
            {
                ModelState.AddModelError("", "Image size must be less than 250kb");
                return View();
            }
            string folder = Path.Combine("images", "service");
            string fileName = await Services.ServiceDetails.Photo.SaveImageAsync(_env.WebRootPath, folder);
            Services.ServiceDetails.Image = fileName;
            Services.ServiceDevelopers = sd;
            Services.IsDeleted = false;

            await _db.Services.AddAsync(Services);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Services Services = _db.Services.Include(s=>s.ServiceDetails).FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Services == null) return NotFound();
            return View(Services);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteService(int? id)
        {
            if (id == null) return NotFound();
            Services Services = _db.Services.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Services == null) return NotFound();
            Services.IsDeleted = true;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            GetDevelopers();
            if (id == null) return NotFound();
            Services Services = _db.Services.Include(t => t.ServiceDetails).Include(ts => ts.ServiceDevelopers).FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Services == null) return NotFound();
            return View(Services);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Services Services, int? id, List<int> developerId)
        {
            GetDevelopers();
            Services viewService = _db.Services.Include(td => td.ServiceDetails).Include(ts => ts.ServiceDevelopers).ThenInclude(d=>d.Developers)
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            List<ServiceDevelopers> sd = new List<ServiceDevelopers>();
            foreach (int item in developerId)
            {
                ServiceDevelopers serviceDevelopers = new ServiceDevelopers()
                {
                    DevelopersId = item,
                    ServicesId = Services.Id,
                };
                    sd.Add(serviceDevelopers);
                    await _db.ServiceDevelopers.AddAsync(serviceDevelopers);
                if (item ==serviceDevelopers.Developers.Id)
                {
                    ModelState.AddModelError("", "Artiq movcuddur");
                }
                    await _db.SaveChangesAsync();
                
            }
            if (Services.ServiceDetails.Photo != null)
            {
                if (!Services.ServiceDetails.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View(viewService);
                }
                if (!Services.ServiceDetails.Photo.MaxSize(250))
                {
                    ModelState.AddModelError("", "Image size must be less than 250kb");
                    return View(viewService);
                }

                string folder = Path.Combine("images", "team");
                string fileName = await Services.ServiceDetails.Photo.SaveImageAsync(_env.WebRootPath, folder);
                viewService.ServiceDetails.Image = fileName;
            }
            viewService.Title = Services.Title;
            Services.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            GetDevelopers();
            if (id == null) return NotFound();
            Services Services = _db.Services.Where(t => t.IsDeleted == false).Include(t => t.ServiceDetails).Include(ts => ts.ServiceDevelopers).FirstOrDefault(t => t.Id == id);
            if (Services == null) return NotFound();
            return View(Services);
        }
        #endregion

        private void GetDevelopers()
        {
            ViewBag.GetDeveloper = _db.Developers.Where(d => d.IsDeleted == false).ToList();
            ViewBag.GetServices = _db.Services.Where(d => d.IsDeleted == false).ToList();
        }
    }
}
