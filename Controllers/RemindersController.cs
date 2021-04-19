using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.IdentityModel.Protocols;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Thyme1.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public RemindersController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> SendEmail()
        {
            //Email
            var message = EmailTemplate("Email");
            message = message.Replace("@ViewBag.Name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Reza"));
            message = message.Replace("@ViewBag.Details", "This is Test Details");
            await SendEmailAsync("towe.allie@gmail.com", "Test subject", message);
            //End Email
            return Json(0);
        }
        public string EmailTemplate(string path)
        {
            string wwwrootPath = webHostEnvironment.WebRootPath;

            string thePath = Path.Combine(wwwrootPath + "/Content/Email");

            return thePath.ToString();
        }

        public class Email
        {
            public string EmailPassword { get; set; }
        }


        public async static Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {

                var _email = "towe.allie@gmail.com";
                var _epass = "I@mLight1";
                var _dispName = "Test Mail";

                MailMessage myMessage = new MailMessage();
                myMessage.To.Add(email);
                myMessage.From = new MailAddress(_email, _dispName);
                myMessage.Subject = subject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_email, _epass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(myMessage);
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
    