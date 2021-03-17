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
        public async Task<IActionResult> Index()
        {
            List<Services> services = _db.Services.Where(t => t.IsDeleted == false).Include(pi => pi.ServiceDetails).Include(pd => pd.ServiceDevelopers).ThenInclude(pd => pd.Developers).ToList();
            return View(services);
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
