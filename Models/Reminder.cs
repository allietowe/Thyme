using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thyme1.Models
{
    public class Reminder
    {
        public int Id { get; set; }

        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public string Email { get; set; }

        [Required]
        public DateTime Time { get; set; }
        public string Message { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        public Reminder (string email, DateTime time, string message, DateTime createdAt)
        {
            Email = email;
            Time = time;
            Message = message;
            CreatedAt = DateTime.Now;
        }

        public Reminder() {}
    }
}
