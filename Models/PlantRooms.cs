using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;

namespace Thyme1.Models
{
    public class PlantRooms
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Plant> Plants { get; set; }

        public PlantRooms()
        {
        }

        public PlantRooms(string name)
        {
            Name = name;
        }

    }
}
