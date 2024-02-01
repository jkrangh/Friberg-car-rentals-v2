using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Admin Add(Admin admin)
        {
            applicationDbContext.Add(admin);
            applicationDbContext.SaveChanges();
            return admin;
        }

        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(x => x.AdminId);
        }

        public Admin GetByEmail(string email)
        {
            return applicationDbContext.Admins
                .FirstOrDefault(x => x.AdminEmail == email);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admins
                .FirstOrDefault(x => x.AdminId == id);
        }

        public void Remove(Admin admin)
        {
            applicationDbContext.Remove(admin);
            applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Admin Update(Admin admin)
        {
            applicationDbContext.Update(admin);
            applicationDbContext.SaveChanges();
            return admin;
        }
    }
}
