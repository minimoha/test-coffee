using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class HotDrink
    {
        public int HotDrinkId { get; set; }
        [Required]
        public string? HotDrinkName { get; set; }
    }
}
