using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GdzieZjemAPI.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<CityRestaurant> CityRestaurants { get; set; }
    }
}