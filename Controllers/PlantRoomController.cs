using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;
using Thyme1.ViewModels;
using Thyme1.Data;

namespace Thyme1.Controllers
{
    public class PlantRoomController : Controller
    {
        private PlantDbContext context;

        public PlantRoomController(PlantDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<PlantRoom> plantRooms = context.PlantRooms.ToList();
            return View(plantRooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddPlantRoomViewModel addPlantRoomViewModel = new AddPlantRoomViewModel();
            return View(addPlantRoomViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreatePlantRoomForm(AddPlantRoomViewModel addPlantRoomViewModel)
        {
            if (ModelState.IsValid)
            {
                PlantRoom newPlantRoom = new PlantRoom
                {
                    Name = addPlantRoomViewModel.Name
                };

                context.PlantRooms.Add(newPlantRoom);
                context.SaveChanges();

                return Redirect("/PlantRoom");
            }

            return View("Create", addPlantRoomViewModel);
        }
    }
}

