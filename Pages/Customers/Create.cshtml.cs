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

namespace Friberg_car_rentals_v2.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public CreateModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            customerRepo.Add(Customer);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.UtcNow.AddHours(1);
            Response.Cookies.Append("CurrentUserName", $"{Customer.FirstName} {Customer.LastName}", options);
            Response.Cookies.Append("CurrentUserId", Customer.Id.ToString(), options);
            
            return RedirectToPage("/Index");
        }
    }
}
