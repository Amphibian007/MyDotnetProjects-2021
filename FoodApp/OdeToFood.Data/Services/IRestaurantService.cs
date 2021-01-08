using OdeToFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantService
    {
         IEnumerable<Restaurant> GetAll();
    }
}
