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

namespace Friberg_car_rentals_v2.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public IndexModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public IList<Admin> Admin { get;set; } = default!;

        public void OnGet()
        {
            Admin = adminRepo.GetAll().ToList();
        }
    }
}
