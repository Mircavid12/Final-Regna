using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class ApplyController : Controller
    {
        private readonly AppDbContext _db;
        public ApplyController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? ServiceId)
        {
            GetServices();
            ApplyVM applyVM = new ApplyVM()
            {
                Apply= _db.Applies.Where(c => c.IsDeleted == false).FirstOrDefault()
            };
            return View(applyVM);
        }

        [HttpPost]
        public IActionResult Indexx(Email email)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "mirjavidaa@code.edu.az",
                    Password = "cako7010480"
                }
            };
            MailAddress fromEmail = new MailAddress("mirjavidaa@code.edu.az",email.FirstName+" "+email.LastName);
            MailAddress toEmail = new MailAddress("mirjavidaa@code.edu.az", "Miri");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = email.Service,
                Body = $" Adı: {email.FirstName+" "+email.LastName}{System.Environment.NewLine} Nömrəsi: {"+994 "+email.PhoneSerie+email.PhoneNumber}{System.Environment.NewLine} Xidmət növü: {email.Service} {System.Environment.NewLine} Mesaj: {email.Message} "
            };
            message.To.Add(toEmail);
            client.Send(message);
            return RedirectToAction("Index", "Apply");
        }

        private void GetServices()
        {
            ViewBag.Service = _db.Services.Where(c => c.IsDeleted == false).ToList();
        }
    }
}
