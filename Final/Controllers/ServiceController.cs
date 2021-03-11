using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;

        public ServiceController( AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            ViewData["GetServices"] = searchString;
            var serviceQuery = from x in _db.Services select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                serviceQuery = serviceQuery.Where(x => x.Title.Contains(searchString) && x.IsDeleted == false);
                return View(await serviceQuery.AsNoTracking().ToListAsync());
            }
            else
            {
                ViewBag.PageCount = Decimal.Ceiling((decimal)_db.Services.Where(s => s.IsDeleted == false).Count() / 6);
                ViewBag.page = page;
                if (page == null)
                {
                    List<Services> service = _db.Services.Where(t => t.IsDeleted == false).Take(6).ToList();
                    return View(service);
                }
                List<Services> service2 = _db.Services.Where(t => t.IsDeleted == false).Skip((int)(page - 1) * 6).Take(6).ToList();
                return View(service2);
            }
        }
        public IActionResult ServiceDetails(int? id)
        {
            if (id == null)
            {
                return View(_db.Services.Where(t => t.IsDeleted == false).Include(sd => sd.ServiceDetails).FirstOrDefault());
            }


            Services services = _db.Services.Where(t => t.IsDeleted == false).Include(sd => sd.ServiceDetails).Include(sd => sd.ServiceDevelopers).ThenInclude(s => s.Developers).FirstOrDefault(t => t.Id == id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }
    }
}
