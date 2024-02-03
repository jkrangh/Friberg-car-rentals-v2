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

namespace Friberg_car_rentals_v2.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBooking bookingRepo;

        public CreateModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public IActionResult OnGet()
        {
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
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

            return RedirectToPage("./Index");
        }
    }
}
