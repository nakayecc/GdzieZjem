using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.dto;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}/restaurant")]
        public ActionResult<RestaurantInCityDao> GetRestaurantByCity(int id)
        {
            if (_cityRepository.FindRestaurantByCityId(id) == null)
                return NotFound();
            return _cityRepository.FindRestaurantByCityId(id);
        }

        // GET: api/city
        [HttpGet("")]
        [Authorize]
        public List<SelectCityDto> GetAllCity()
        {
            return _cityRepository.GetAllCity();
        }

        // POST: api/city
        [HttpPost]
        public Task<ActionResult<City>> PostCity(City city)
        {
            return _cityRepository.PostCity(city)
                ? Task.FromResult<ActionResult<City>>(Created("ssss", city))
                : Task.FromResult<ActionResult<City>>(BadRequest("City: " + city.Name + " Exist in DB"));
        }
        
        //DELETE : api/city
        [HttpDelete("{id}")]
        public Task<ActionResult<City>> DeleteCity(int id)
        {
            return _cityRepository.RemoveCity(id)
                ? Task.FromResult<ActionResult<City>>(Ok("Removed city id: " + id))
                : Task.FromResult<ActionResult<City>>(BadRequest("City not exist on Id: " + id));
        }
        
        
    }
}