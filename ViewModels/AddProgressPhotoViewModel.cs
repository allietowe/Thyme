using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Thyme1.Models;

namespace Thyme1.ViewModels
{
    public class AddProgressPhotoViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Taken { get; set; }
        public string Name { get; set; }
        public string PhotoName { get; set; }
        public int PlantId { get; set; }
        public List<SelectListItem> Plant { get; set; }
        public IFormFile ImageFile { get; set; }

        public AddProgressPhotoViewModel(List<Plant> plants)
        {
            Plant = new List<SelectListItem>();

            foreach (var plant in plants)
            {
                Plant.Add(
                    new SelectListItem
                    {
                        Value = plant.Id.ToString(),
                        Text = plant.PlantName
                    }
                    );
            }
        }

        public AddProgressPhotoViewModel() { } 
    }
}
