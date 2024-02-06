using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public class Booking
    {
        //TODO: Change CarId and CustomerId to actual objects for added display information in booking CRUD
        [Display(Name = "Bokningsnummer")]
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Hyr från")]
        public DateTime RentalStart { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Hyr till")]
        public DateTime RentalEnd { get; set; }
    }
}
