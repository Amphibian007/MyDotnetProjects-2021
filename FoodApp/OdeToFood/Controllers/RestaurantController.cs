using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Services;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantService _restaurantService;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public RestaurantController(IConfiguration configuration, IRestaurantService restaurantService)
        {
            _configuration = configuration;
            _restaurantService = restaurantService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Restaurant()
        {
            Restaurants = _restaurantService.GetAll();
            return View(Restaurants);
        }

    }
}
