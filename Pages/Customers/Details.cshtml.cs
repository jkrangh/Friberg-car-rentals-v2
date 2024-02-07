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

namespace Friberg_car_rentals_v2.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public DetailsModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];

            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepo.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
