using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }


    public class InMemoryRestaurantData : IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll()
        {
            return new List<Restaurant>
            {
                new Restaurant {Id = 2, Name = "Spectacular"},
                new Restaurant {Id = 3, Name = "Mandarin"},
                new Restaurant {Id = 4, Name = "Free dence food"},
                new Restaurant {Id = 5, Name = "Smoke white fresh"}
            };
        }
    }
}
