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
    public class DeleteModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public DeleteModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = adminRepo.GetById(id);

            if (admin == null)
            {
                return NotFound();
            }
            else
            {
                Admin = admin;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = adminRepo.GetById(id);
            if (admin != null)
            {
                Admin = admin;
                adminRepo.Remove(Admin);
            }

            return RedirectToPage("./Index");
        }
    }
}
