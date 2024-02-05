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
    public class ListCustomerBookingsModel : PageModel
    {
        private readonly IBooking bookingRepo;

        public ListCustomerBookingsModel(IBooking bookingRepo)
        {            
            this.bookingRepo = bookingRepo;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public void OnGet()
        {
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
            Booking = bookingRepo.GetByCustomer(Int32.Parse((string)ViewData["CurrentUserId"])).ToList();
        }
    }
}
