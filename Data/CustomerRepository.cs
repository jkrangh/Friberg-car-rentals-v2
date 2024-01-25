using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Customer Add(Customer cust)
        {
            applicationDbContext.Add(cust);
            return cust;
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(x => x.LastName);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customers
                .FirstOrDefault(x => x.CustomerId == id);
        }

        public void Remove(Customer cust)
        {
            applicationDbContext.Remove(cust);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Customer Update(Customer cust)
        {
            applicationDbContext.Update(cust);
            return cust;
        }
    }
}
