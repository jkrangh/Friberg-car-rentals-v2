using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime RentalStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime RentalEnd { get; set; }
    }
}
