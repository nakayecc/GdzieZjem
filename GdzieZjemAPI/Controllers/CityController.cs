using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.Dao;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GdzieZjemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: api/city/{id}
        [HttpGet("{id}")]
        public ActionResult<RestaurantInCityDao> GetRestaurantByCity(int id)
        {
            if (_cityRepository.FindRestaurantByCityId(id) == null)
                return NotFound();
            return _cityRepository.FindRestaurantByCityId(id);
        }
        
    }
}