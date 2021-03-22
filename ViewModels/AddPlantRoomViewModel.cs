using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thyme1.ViewModels
{
    public class AddPlantRoomViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters long")]
        public string Name { get; set; }

    }
}
