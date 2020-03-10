using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GdzieZjemAPI.Services
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApiContext context) : base(context)
        {
        }

        public RestaurantInCityDao FindRestaurantByCityId(int cityId)
        {
            if (GetContext().Find(cityId) == null)
                return null;

            var restaurantInCityDao = new RestaurantInCityDao();
            restaurantInCityDao.City = GetContext().Find(cityId).Name;

            var quarry = GetContext()
                .Where(c => c.Id == cityId)
                .SelectMany(p => p.CityRestaurants)
                .Select(pc => pc.Restaurant)
                .ToList();

            foreach (var restaurant in quarry)
            {
                restaurantInCityDao.Restaurant.Add(new SelectRestaurantDto()
                {
                    Address = restaurant.Address,
                    Name = restaurant.Name,

                });
            }

            return restaurantInCityDao;
        }

        public List<SelectCityDto> GetAllCity()
        {
            var query = GetContext().Select(m => new SelectCityDto()
                {
                    CityName = m.Name
                })
                .ToList();
            return query;
        }

        public bool PostCity(City city)
        {
            if (GetContext().FirstOrDefault(c => c.Name == city.Name) != null)
                return false;
            Insert(city);
            Save();
            return true;
        }

        public bool RemoveCity(int id)
        {
            if (GetContext().Find(id) == null)
                return false;
            Delete(id);
            Save();
            return true;
        }

        public List<SelectRestaurantDto> GetAllRestaurantByCity(string cityName)
        {
            var restaurantList = new List<SelectRestaurantDto>();

            var quarry = GetContext()
                .Where(c => c.Name == cityName)
                .Include(cr => cr.CityRestaurants)
                .ThenInclude(r => r.Restaurant);

            foreach (var city in quarry)
            {
                restaurantList.AddRange(city.CityRestaurants.Select(cityRestaurant => new SelectRestaurantDto
                {
                    Address = cityRestaurant.Restaurant.Address,
                    Name = cityRestaurant.Restaurant.Name
                }));
            }
            
            return restaurantList;
        }
    }
}