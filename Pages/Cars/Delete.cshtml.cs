﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Models;
using Friberg_car_rentals_v2.Data;

namespace Friberg_car_rentals_v2.Pages.Cars
{
    public class DeleteModel : PageModel
    {        
        private readonly ICar carRepo;

        public DeleteModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];
            if (id == null)
            {
                return NotFound();
            }

            var car = carRepo.GetById(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carRepo.GetById(id);
            if (car != null)
            {
                Car = car;
                carRepo.Remove(Car);
            }

            return RedirectToPage("./Index");
        }
    }
}
