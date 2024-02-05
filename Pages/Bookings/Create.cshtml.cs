using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Models;
using Friberg_car_rentals_v2.Data;
using System.Text.Encodings.Web;

namespace Friberg_car_rentals_v2.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBooking bookingRepo;

        public CreateModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public IActionResult OnGet(int carId)
        {
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
            ViewData["CurrentUserName"] = Request.Cookies["CurrentUserName"];
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];

            if (ViewData["CurrentUserId"] == null && ViewData["CurrentAdmin"] == null) //If no user has logged in, create booking is redirected to login-page
            {
                return RedirectToPage("/Login/Login");
            }
            Booking = new Booking
            {
                CarId = carId,
                CustomerId = Int32.Parse((string)ViewData["CurrentUserId"]),
                RentalStart = DateTime.Now,
                RentalEnd = DateTime.Now.AddDays(1)         
            };
            
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bookingRepo.Add(Booking);

            return RedirectToPage("./ListCustomerBookings");
        }
    }
}
