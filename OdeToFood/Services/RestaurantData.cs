using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }


    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> _restaurants;

       
        // COMPLITLY NOT THREAD SAVE
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
             {
                new Restaurant {Id = 2, Name = "Spectacular"},
                new Restaurant {Id = 3, Name = "Mandarin"},
                new Restaurant {Id = 4, Name = "Free dence food"},
                new Restaurant {Id = 5, Name = "Smoke white fresh"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
           _restaurants.Add(newRestaurant);
            return newRestaurant;
        }
    }
}
