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

namespace Friberg_car_rentals_v2.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ICar carRepo;

        public EditModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carRepo.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
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
                    carRepo.Update(Car);
                }
                catch (Exception ex)
                {
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }

        //private bool CarExists(int id)
        //{
        //    return _context.Cars.Any(e => e.CarId == id);
        //}
    }
}
