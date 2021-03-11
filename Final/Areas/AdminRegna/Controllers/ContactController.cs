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

namespace Final.Areas.AdminRegna.Controllers
{
    [Area("AdminRegna")]
    [Authorize("Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_db.Contacts.Where(a => a.IsDeleted == false).FirstOrDefault());
        }

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Contact Contact = _db.Contacts.FirstOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (Contact == null) return NotFound();
            return View(Contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Contact Contact, int? id)
        {
            Contact viewContact = _db.Contacts
                   .FirstOrDefault(t => t.Id == id && t.IsDeleted == false);

            if (Contact.Photo != null)
            {
                if (!Contact.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please select image type");
                    return View(viewContact);
                }
                if (!Contact.Photo.MaxSize(250))
                {
                    ModelState.AddModelError("", "Image size must be less than 250kb");
                    return View(viewContact);
                }

                string folder = Path.Combine("images");
                string fileName = await Contact.Photo.SaveImageAsync(_env.WebRootPath, folder);
                viewContact.Image = fileName;
            }
            viewContact.Address = Contact.Address;
            viewContact.Mail = Contact.Mail;
            viewContact.PhoneNumber = Contact.PhoneNumber;
            Contact.IsDeleted = false;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detail
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Contact Contact = _db.Contacts.Where(t => t.IsDeleted == false).FirstOrDefault(t => t.Id == id);
            if (Contact == null) return NotFound();
            return View(Contact);
        }
        #endregion
    }
}
