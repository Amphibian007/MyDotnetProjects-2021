using OdeToFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class RestaurantService : IRestaurantService
    {
         List<Restaurant> restaurants;
        public RestaurantService()
        {
            restaurants = new List<Restaurant>()
            {
             new Restaurant{Id=1,Name="Food Palace",Location="Dhaka",Cuisine=CuisineType.Indian},
             new Restaurant{Id=2,Name="Shiny Food",Location="Gazipur",Cuisine=CuisineType.Italian},
             new Restaurant{Id=3,Name="Rising Food",Location="Narsingdi",Cuisine=CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from res in restaurants  
                   orderby res.Name
                   select res;
                  
        }
    }
}
