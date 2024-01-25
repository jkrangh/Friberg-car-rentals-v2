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
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepo;

        public IndexModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public void OnGet()
        {
            Customer = customerRepo.GetAll().ToList();
        }
    }
}
