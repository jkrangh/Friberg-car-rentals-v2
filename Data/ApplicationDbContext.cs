using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Friberg_car_rentals_v2.Models.Car> Cars { get; set; } = default!;
        public DbSet<Friberg_car_rentals_v2.Models.Customer> Customers { get; set; } = default!;
        public DbSet<Friberg_car_rentals_v2.Models.Admin> Admins { get; set; } = default!;
        public DbSet<Friberg_car_rentals_v2.Models.Booking> Bookings { get; set; } = default!;
    }
}
