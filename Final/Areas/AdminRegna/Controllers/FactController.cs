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
    public class FactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public FactController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.FactCounters.Where(d => d.IsDeleted == false).ToList());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            FactCounters Facts = _db.FactCounters.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Facts == null) return NotFound();
            return View(Facts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FactCounters Facts, int? id)
        {
            FactCounters viewFacts = _db.FactCounters
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            viewFacts.Name = Facts.Name;
            viewFacts.Count = Facts.Count;
            Facts.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
