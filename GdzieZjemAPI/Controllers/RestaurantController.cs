using System.Collections.Generic;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.dto;
using Microsoft.AspNetCore.Mvc;

namespace GdzieZjemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        // GET
        [HttpPost("Get")]
        public List<RestaurantFullLocalization> RestaurantGetBy( string restaurantName, string restaurantAddress)
        {
            return _repository.GetRestaurantFullLocalizationBy(restaurantName, restaurantAddress);
        }
    }
}