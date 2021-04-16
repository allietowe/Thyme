using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thyme1.Models
{
    public class Plant
    {
        public string PlantName { get; set; }
        public string PlantGenus { get; set; }
        public DateTime LastWatered { get; set; }
        public DateTime LastFertilized { get; set; }
        public PlantRooms PlantRoom { get; set; }
        public int PlantRoomId { get; set; }
        public int Id { get; set; }


        public Plant(string plantName, string plantGenus, DateTime lastWatered, DateTime lastFertlized)
        {
            PlantName = plantName;
            PlantGenus = plantGenus;
            LastWatered = lastWatered;
            LastFertilized = lastFertlized;
        }

        public Plant()
        {

        }
        public override string ToString()
        {
            return PlantName;
        }

        public override bool Equals(object obj)
        {
            return obj is Plant @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
