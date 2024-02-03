using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Booking Add(Booking booking)
        {
            applicationDbContext.Add(booking);
            applicationDbContext.SaveChanges();
            return booking;
        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Bookings.OrderBy(x => x.BookingId);
        }

        public IEnumerable<Booking> GetByCustomer(int id)
        {
            return applicationDbContext.Bookings
                .Where(x => x.CustomerId == id).OrderBy(x => x.BookingId).ToList();
        }

        public Booking GetById(int id)
        {
            return applicationDbContext.Bookings
                .FirstOrDefault(x => x.BookingId == id);
        }

        public void Remove(Booking booking)
        {
            applicationDbContext.Remove(booking);
            applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Booking Update(Booking booking)
        {
            applicationDbContext.Update(booking);
            applicationDbContext.SaveChanges();
            return booking;
        }       
    }
}
