using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        IEnumerable<Car> GetAllAvailable();
        Car Add(Car car);
        void SaveChanges();
        Car Update(Car car);
        void Remove(Car car);
    }
}
