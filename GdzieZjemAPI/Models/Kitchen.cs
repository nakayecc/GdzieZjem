using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GdzieZjemAPI.Models
{
    [Table("Kitchens")]
    public class Kitchen
    {
        [Key]
        public int Id { get; set; }
        public string KitchenName { get; set; }
        
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}