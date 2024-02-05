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
    public class DeleteModel : PageModel
    {
        private readonly IBooking bookingRepo;

        public DeleteModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
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
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];
            //ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingRepo.GetById(id);
            if (booking != null)
            {
                Booking = booking;
                bookingRepo.Remove(Booking);
            }
            if (ViewData["CurrentAdmin"] != null)
            {
                return RedirectToPage("./Index");
            }
            else { return RedirectToPage("./ListCustomerBookings"); }
        }
    }
}
