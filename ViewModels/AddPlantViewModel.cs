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
        public string PlantName { get; set; }
        public string PlantGenus { get; set; }
        public DateTime LastWatered { get; set; }
        public DateTime LastFertilized { get; set; }
        public int PlantRoomId { get; set; }
        public List<SelectListItem> PlantRooms { get; set; }

        public AddPlantViewModel(List<PlantRooms> plantRooms)
        {
            PlantRooms = new List<SelectListItem>();

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
