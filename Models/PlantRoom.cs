using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;

namespace Thyme1.Models
{
    public class PlantRoom
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Plant> plants { get; set; }

        public PlantRoom()
        {
        }

        public PlantRoom(string name)
        {
            Name = name;
        }

    }
}
