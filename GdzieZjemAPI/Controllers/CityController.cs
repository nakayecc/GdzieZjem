using System.Collections.Generic;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
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

        // GET: api/city
        [HttpGet]
        public List<City> Index()
        {
            return _cityRepository.GetAll();
        }
    }
}