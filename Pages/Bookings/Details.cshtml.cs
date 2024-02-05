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
    public class DetailsModel : PageModel
    {
        private readonly IBooking bookingRepo;
        private readonly ICar carRepo;

        public DetailsModel(IBooking bookingRepo, ICar carRepo)
        {
            this.bookingRepo = bookingRepo;
            this.carRepo = carRepo;
        }

        public Booking Booking { get; set; } = default!;
        public Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingRepo.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
                Car = carRepo.GetById(booking.CarId);
            }
            return Page();
        }
    }
}
