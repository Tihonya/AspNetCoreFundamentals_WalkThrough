using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required]
        [Display(Name = "Restaurant Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public CuisineType Cuisine { get; set; }

    }
}
