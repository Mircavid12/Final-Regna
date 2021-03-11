using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.DAL;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;

        public PortfolioController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Portfolio> portfolios = _db.Portfolios.Where(t => t.IsDeleted == false).Include(pi => pi.PortfolioImages).Include(pd=>pd.PortfolioDevelopers).ThenInclude(pd=>pd.Developers).ToList();
            return View(portfolios);
        }
        public IActionResult PortfolioDetails(int? id)
        {
            if (id == null)
            {
                return View(_db.Portfolios.Where(t => t.IsDeleted == false).Include(sd => sd.PortfolioDetails).FirstOrDefault());
            }


            Portfolio portfolio = _db.Portfolios.Where(t => t.IsDeleted == false).Include(sd => sd.PortfolioDetails).Include(pi=>pi.PortfolioImages).Include(sd => sd.PortfolioDevelopers).ThenInclude(s => s.Developers).FirstOrDefault(t => t.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }
    }
}
