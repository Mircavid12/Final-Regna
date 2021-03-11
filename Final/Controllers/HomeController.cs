using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Final.Models;
using Final.DAL;
using Final.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger,AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Intro=_db.Intros.Where(i => i.IsDeleted == false).FirstOrDefault(),
                About=_db.Abouts.Where(a=>a.IsDeleted==false).FirstOrDefault(),
                AboutDetails=_db.AboutDetails.Where(ad=>ad.IsDeleted==false).ToList(),
                Facts = _db.Facts.Where(f => f.IsDeleted == false).FirstOrDefault(),
                FactCounters = _db.FactCounters.Where(fc => fc.IsDeleted == false).ToList(),
                Services = _db.Services.Where(s=>s.IsDeleted==false).ToList(),
                Portfolios=_db.Portfolios.Where(p=>p.IsDeleted==false).Include(pi=>pi.PortfolioImages).ToList(),
                Developers=_db.Developers.Where(d=>d.IsDeleted==false).ToList(),
                Parallax = _db.Parallaxes.Where(p => p.IsDeleted == false).FirstOrDefault()
                
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
