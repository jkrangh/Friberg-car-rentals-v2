using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Models;
using Friberg_car_rentals_v2.Data;

namespace Friberg_car_rentals_v2.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBooking bookingRepo;

        public IndexModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public void OnGet()
        {
            Booking = bookingRepo.GetAll().ToList();
        }
    }
}
