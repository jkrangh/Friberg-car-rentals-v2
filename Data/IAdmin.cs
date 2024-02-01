using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public interface IAdmin
    {
        Admin GetById(int id);
        IEnumerable<Admin> GetAll();
        Admin Add(Admin admin);
        void SaveChanges();
        Admin Update(Admin admin);
        void Remove(Admin admin);
        Admin GetByEmail(string email);
    }
}
