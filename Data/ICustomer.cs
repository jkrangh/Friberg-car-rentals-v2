using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public interface ICustomer
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();
        Customer Add(Customer cust);
        void SaveChanges();
        Customer Update(Customer cust);
        void Remove(Customer cust);
    }
}
