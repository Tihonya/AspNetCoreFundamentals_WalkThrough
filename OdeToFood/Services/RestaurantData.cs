using System.Collections.Generic;
using System.Linq;
using OdeToFood.DataLayer;
using OdeToFood.Models;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant restaurant);
        void Commit();
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }
        

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant Get(int id)
        {
           return _context.Restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant); 
           return newRestaurant;

        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Update(restaurant);
            return restaurant;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
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

        public Restaurant Update(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
