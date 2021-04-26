using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Data;
using Thyme1.Models;
using Thyme1.ViewModels;

namespace Thyme1.Controllers
{
    public class ProgressPhotoController : Controller
    {
        private readonly PlantDbContext context;
        private readonly IWebHostEnvironment hostEnvironment;

        public ProgressPhotoController(PlantDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            context = dbContext;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Image
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await context.ProgressPhotos.ToListAsync());
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await context.ProgressPhotos
                .FirstOrDefaultAsync(m => m.ProgressPhotoID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            List<Plant> plants = context.Plants.ToList();
            AddProgressPhotoViewModel addProgressPhotoViewModel = new AddProgressPhotoViewModel(plants);
            return View(addProgressPhotoViewModel);
        }

        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageID,Name,ImageFile")] ProgressPhotos imageModel, AddProgressPhotoViewModel addProgressPhotoViewModel)
        {
            if (ModelState.IsValid)
            {

                //save image to wwwroot folder
                string wwwrootPath = hostEnvironment.WebRootPath;
                string FileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.Name = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwrootPath + "/Images/" + FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }

                Plant thePlant = context.Plants.Find(addProgressPhotoViewModel.PlantId);
                ProgressPhotos newProgressPhoto = new ProgressPhotos
                {
                    Name = addProgressPhotoViewModel.Name,
                    Plant = thePlant,
                    PhotoName = addProgressPhotoViewModel.PhotoName
                    
                };


                //insert record
                context.Add(imageModel);
                context.ProgressPhotos.Add(newProgressPhoto);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await context.ProgressPhotos.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            return View(imageModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageID,title,ImageName")] ProgressPhotos imageModel)
        {
            if (id != imageModel.ProgressPhotoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(imageModel);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.ProgressPhotoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await context.ProgressPhotos
                .FirstOrDefaultAsync(m => m.ProgressPhotoID == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await context.ProgressPhotos.FindAsync(id);
            context.ProgressPhotos.Remove(imageModel);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageModelExists(int id)
        {
            return context.ProgressPhotos.Any(e => e.ProgressPhotoID == id);
        }
    }
}
    
