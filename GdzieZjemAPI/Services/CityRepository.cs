using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;

namespace GdzieZjemAPI.Services
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApiContext context) : base(context)
        {
        }
        
        
        
    }
}