using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly Friberg_car_rentals_v2.ApplicationDbContext _context;

        public DetailsModel(Friberg_car_rentals_v2.ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
