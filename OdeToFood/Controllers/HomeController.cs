using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var viewModel = new HomePageViewModel();
            viewModel.Restaurants = _restaurantData.GetAll();

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
//                return NotFound();
//                return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Create()
        {
            var viewModel = new RestaurantEditViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel viewModel )
        {
            if (!ModelState.IsValid)
            {
                
                return View(viewModel);
            }
            var newRestaurant = new Restaurant
            {
                Name = viewModel.Name,
                Cuisine = viewModel.Cuisine
            };

        newRestaurant=  _restaurantData.Add(newRestaurant);
            _restaurantData.Commit();
            return RedirectToAction(nameof(Details),new { id = newRestaurant.Id});
        }

        public IActionResult Edit(int id)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant == null)
            {
                RedirectToAction(nameof(Index));
            }
            var viewModel = new RestaurantEditViewModel
            {
                Name = restaurant.Name,
                Cuisine = restaurant.Cuisine,
           
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel viewModel)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant == null)
            {
                return NoContent();
            }
           if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            restaurant.Name = viewModel.Name;
            restaurant.Cuisine = viewModel.Cuisine;

            restaurant = _restaurantData.Update(restaurant);
            _restaurantData.Commit();

            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
        }


    }
}
