using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Thyme1.Models;

namespace Thyme1.Email
{
    public interface IEmailService {
        void SendReminderAsync(Reminder reminder);

    }
    public class EmailService : IEmailService
    {
        public void SendReminderAsync(Reminder reminder)
               {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("towe.allie@gmail.com", "I@mLight1");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("towe.allie@gmail.com");
                    mailMessage.To.Add(reminder.Email);
                    mailMessage.Subject = $"Your reminder for {reminder.Time.ToShortDateString()}";
                    mailMessage.Body = reminder.Message;
                    client.Send(mailMessage);
                }
            }
        }
}
