using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Car Add(Car car)
        {
            applicationDbContext.Add(car);
            applicationDbContext.SaveChanges();
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(c => c.CarMake);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars
                .FirstOrDefault(c => c.CarId == id);
        }

        public void Remove(Car car)
        {
            applicationDbContext.Remove(car);
            applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Car Update(Car car)
        {
            applicationDbContext.Update(car);
            applicationDbContext.SaveChanges();
            return (car);
        }
    }
}
