using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public string CarMake { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Range(1886, 2024)]
        public int CarYear { get; set; }
        [DataType(DataType.Currency)]
        public decimal RentalPrice { get; set; }
        public string Color { get; set; } = "";
        public string Description { get; set; } = "";
        public bool CurrentlyAvailable { get; set; }
        public string? CarImageURL { get; set; } = "~friberg_logo.png";
    }
}
