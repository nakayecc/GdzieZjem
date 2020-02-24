using System;
using System.Collections.Generic;
using System.Linq;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.Dao;
using Microsoft.EntityFrameworkCore;

namespace GdzieZjemAPI.Services
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApiContext context) : base(context)
        {
        }

        public List<RestaurantFullLocalization> GetRestaurantFullLocalizationBy(string name, string address)
        {
            var restaurantList = new List<RestaurantFullLocalization>();

            var quarry = GetContext()
                .Where(res => res.Name == name && res.Address == address)
                .Include(cr => cr.CityRestaurants)
                .ThenInclude(c => c.City);

            foreach (var restaurant in quarry)
            {
                restaurantList.AddRange(restaurant.CityRestaurants.Select(cityRestaurant =>
                    new RestaurantFullLocalization
                    {
                        Name = cityRestaurant.Restaurant.Name, 
                        Address = cityRestaurant.Restaurant.Address,
                        City = cityRestaurant.City.Name
                    }));
            }


            return restaurantList;
        }

        public RestaurantFullLocalization GetRestaurantFullLocalization()
        {
            throw new System.NotImplementedException();
        }
    }
}