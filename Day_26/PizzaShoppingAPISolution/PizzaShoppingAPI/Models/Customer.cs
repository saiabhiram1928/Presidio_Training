using System.ComponentModel.DataAnnotations;

namespace PizzaShoppingAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Image { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; }

        public ICollection<Pizza>? Pizzas { get; set; }
    }
}
