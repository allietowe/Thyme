using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;
using Thyme1.ViewModels;
using Thyme1.Data;

namespace Plants.Controllers
{
    [Authorize]
    public class PlantsController : Controller
    {

        private PlantDbContext context;

        public PlantsController(PlantDbContext dbContext)
        {
            context = dbContext;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Plant> plants = context.Plants
                .Include(e => e.PlantRoom)
                .ToList();
            return View();
        }

        public IActionResult Add()
        {
            List<PlantRoom> rooms = context.PlantRooms.ToList();
            AddPlantViewModel addPlantViewModel = new AddPlantViewModel(rooms);
            return View(addPlantViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddPlantViewModel addPlantViewModel)
        {
            if (ModelState.IsValid)
            {
                PlantRoom thePlantRoom = context.PlantRooms.Find(addPlantViewModel.PlantRoomId);
                Plant newPlant = new Plant
                {
                    PlantName = addPlantViewModel.PlantName,
                    PlantGenus = addPlantViewModel.PlantGenus,
                    LastWatered = addPlantViewModel.LastWatered,
                    LastFertilized = addPlantViewModel.LastFertilized,
                    PlantRoom = thePlantRoom
                };

                context.Plants.Add(newPlant);
                context.SaveChanges();

                return Redirect("/Plants");
            }

            return View(addPlantViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.plants = context.Plants.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] plantIds)
        {
            foreach (int plantId in plantIds)
            {
                Plant thePlant = context.Plants.Find(plantId);
                context.Plants.Remove(thePlant);
            }

            context.SaveChanges();

            return Redirect("/Plants");
        }

        [Route("/Plants/Edit/{plantId}")]
        public IActionResult Edit(int plantId)
        {
            Plant model = context.Plants.Find(plantId);
            ViewBag.Plant = model;

            ViewBag.Title = $"Edit Plant {model.PlantName} (id = {model.Id})";
            return View();
        }

        [HttpPost]
        [Route("/Plants/Edit")]
        public IActionResult SubmitEditPlantForm(int plantId, string plantName, string plantGenus, DateTime lastWatered, DateTime lastFertilized)
        {
            var plantToUpdate = context.Plants.Find(plantId);
            plantToUpdate.PlantName = plantName;
            plantToUpdate.PlantGenus = plantGenus;
            plantToUpdate.LastWatered = lastWatered;
            plantToUpdate.LastFertilized = lastFertilized;


            context.SaveChanges();
            return Redirect("/Plants");

        }

        public IActionResult Detail(int id)
        {
            Plant thePlant = context.Plants
                .Include(e => e.PlantRoom)
                .Single(e => e.Id == id);


            PlantDetailViewModel viewModel = new PlantDetailViewModel(thePlant);
            return View(viewModel);
        }
    }
}
