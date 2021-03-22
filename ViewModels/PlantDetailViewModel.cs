using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;

namespace Thyme1.ViewModels
{
    public class PlantDetailViewModel
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantGenus { get; set; }
        public DateTime LastWatered { get; set; }
        public DateTime LastFertilized { get; set; }
        public string PlantRoomName { get; set; }


        public PlantDetailViewModel(Plant thePlant)
        {
            PlantId = thePlant.Id;
            PlantName = thePlant.PlantName;
            PlantGenus = thePlant.PlantGenus;
            LastWatered = thePlant.LastWatered;
            LastFertilized = thePlant.LastFertilized;
            PlantRoomName = thePlant.PlantRoom.Name;

        }
    }
}
