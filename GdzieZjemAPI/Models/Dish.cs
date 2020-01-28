using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GdzieZjemAPI.Models
{
    [Table("Dishes")]
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        [ForeignKey("Kitchens")]
        public int KitchenId { get; set; }

        public virtual Kitchen Kitchens { get; set; }
        public virtual ICollection<DishRestaurant> DishRestaurants { get; set; }

    }
}  