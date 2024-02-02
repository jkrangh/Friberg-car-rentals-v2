using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public class Customer : User
    {
        public virtual List<Booking> Bookings { get; set; }
    }
}
