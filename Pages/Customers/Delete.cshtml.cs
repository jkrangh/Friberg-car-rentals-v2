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
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public DeleteModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [BindProperty]
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

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepo.GetById(id);
            if (customer != null)
            {
                Customer = customer;
                customerRepo.Remove(Customer);
            }

            return RedirectToPage("./Index");
        }
    }
}
