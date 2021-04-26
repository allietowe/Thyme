using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;
using Thyme1.ViewModels;
using Thyme1.Data;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<PlantRooms> plantRooms = context.PlantRooms.ToList();
            return View(plantRooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddPlantRoomViewModel addPlantRoomViewModel = new AddPlantRoomViewModel();
            return View(addPlantRoomViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddPlantRoomViewModel addPlantRoomViewModel)
        {
            if (ModelState.IsValid)
            {
                PlantRooms newPlantRoom = new PlantRooms
                {
                    Name = addPlantRoomViewModel.Name
                };

                context.PlantRooms.Add(newPlantRoom);
                context.SaveChanges();

                return Redirect("/PlantRoom");
            }

            return View(addPlantRoomViewModel);
        }
    }
}

