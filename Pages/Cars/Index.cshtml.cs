﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Friberg_car_rentals_v2;
using Friberg_car_rentals_v2.Models;

namespace Friberg_car_rentals_v2.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Friberg_car_rentals_v2.ApplicationDbContext _context;

        public IndexModel(Friberg_car_rentals_v2.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}
