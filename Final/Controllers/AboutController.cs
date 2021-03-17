using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.DAL;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                About = _db.Abouts.Where(a => a.IsDeleted == false).FirstOrDefault(),
                AboutDetails = _db.AboutDetails.Where(ad => ad.IsDeleted == false).ToList(),
                Services = _db.Services.Where(s=>s.IsDeleted==false).ToList()
                
            };
            return View(aboutVM);
        }
    }
}
