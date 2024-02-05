using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Models;
using Friberg_car_rentals_v2.Data;

namespace Friberg_car_rentals_v2.Pages.Admins
{
    public class EditModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public EditModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];
            if (id == null)
            {
                return NotFound();
            }

            var admin =  adminRepo.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            Admin = admin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    adminRepo.Update(Admin);
                }
                catch (Exception ex)
                {
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }

        //private bool AdminExists(int id)
        //{
        //    return _context.Admins.Any(e => e.AdminId == id);
        //}
    }
}
