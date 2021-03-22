using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;

namespace Thyme1.ViewModels
{
    public class AddPlantViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters long")]
        public string PlantName { get; set; }

        [Required(ErrorMessage = "Please enter description for event")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string PlantGenus { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        public DateTime LastWatered { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public DateTime LastFertilized { get; set; }

        public int PlantRoomId { get; set; }

        public List<SelectListItem> PlantRooms { get; set; }

        public AddPlantViewModel(List<PlantRoom> plantRooms)
        {
            PlantRooms = new List<SelectListItem>(PlantRooms);

            foreach (var room in plantRooms)
            {
                PlantRooms.Add(
                    new SelectListItem
                    {
                        Value = room.Id.ToString(),
                        Text = room.Name
                    }
                    );
            }
        }

        public AddPlantViewModel() { }
    }
}
