﻿using System;
using System.Collections.Generic;
using System.Linq;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.Dao;
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
                restaurantInCityDao.Restaurant.Add(new SelectRestaurantDao()
                {
                    Address = restaurant.Address,
                    Name = restaurant.Name
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
            



           return null;
        }
    }
}