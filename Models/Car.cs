using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        [Display(Name = "Märke")]
        public string CarMake { get; set; }
        [Required]
        [Display(Name = "Modell")]
        public string CarModel { get; set; }
        [Range(1886, 2024)]
        [Display(Name = "Årsmodell")]
        public int CarYear { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Pris")]
        public decimal RentalPrice { get; set; }
        [Display(Name = "Färg")]
        public string Color { get; set; } = "";
        [Display(Name = "Beskrivning")]
        public string? Description { get; set; } = "";
        [Display(Name = "Tillgänglig")]
        public bool CurrentlyAvailable { get; set; }
        [Display(Name = "Bildlänk")]
        public string? CarImageURL { get; set; } = "https://cdn.discordapp.com/attachments/1146565355607687198/1194279590248591410/friberg_logo.png";
        public virtual List<Booking> Bookings { get; set; }
    }
}
