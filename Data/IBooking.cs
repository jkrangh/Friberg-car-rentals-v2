using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        Booking Add(Booking booking);
        void SaveChanges();
        Booking Update(Booking booking);
        void Remove(Booking booking);
        IEnumerable<Booking> GetByCustomer(int id);
    }
}
