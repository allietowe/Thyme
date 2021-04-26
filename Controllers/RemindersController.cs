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
using Thyme1.Data;
using Thyme1.ViewModels;
using Thyme1.Models;
using Microsoft.EntityFrameworkCore;
using Thyme1.Email;
using Microsoft.AspNetCore.Authorization;

namespace Thyme1.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private PlantDbContext context;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public RemindersController(IWebHostEnvironment webHostEnvironment, PlantDbContext dbContext, IBackgroundJobClient backgroundJobClient)
        {
            this.webHostEnvironment = webHostEnvironment;
            context = dbContext;
            _backgroundJobClient = backgroundJobClient;

        }

        [Authorize]
        public IActionResult Index()
        {
            List<Reminder> reminders = context.Reminders
                .Include(e => e.Plant)
                .ToList();
            return View(reminders);
        }

        public IActionResult Create()
        {
            List<Plant> plants = context.Plants.ToList();
            AddReminderViewModel addReminderViewModel = new AddReminderViewModel(plants);
            return View(addReminderViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddReminderViewModel addReminderViewModel)
        {
            if (ModelState.IsValid)
            {
                Plant thePlant = context.Plants.Find(addReminderViewModel.PlantId);
                Reminder newReminder = new Reminder
                {
                    Email = addReminderViewModel.EmailAddress,
                    Message = addReminderViewModel.Message,
                    Time = addReminderViewModel.ReminderTime,
                    Plant = thePlant
                };

                context.Reminders.Add(newReminder);
                _backgroundJobClient.Schedule<EmailService>(x => x.SendReminderAsync(newReminder), new
                    DateTimeOffset(newReminder.Time));
                context.SaveChanges();

                return Redirect("/Reminders");
            }

            return View(addReminderViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.reminders = context.Reminders.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] reminderIds)
        {
            foreach (int reminderId in reminderIds)
            {
                Reminder theReminder = context.Reminders.Find(reminderId);
                context.Reminders.Remove(theReminder);
            }

            context.SaveChanges();

            return Redirect("/Reminders");
        }
    }
}