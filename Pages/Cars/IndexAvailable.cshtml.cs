using Friberg_car_rentals_v2.Data;
using Friberg_car_rentals_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_car_rentals_v2.Pages.Cars
{
    public class IndexAvailableModel : PageModel
    {
        private readonly ICar carRepo;

        public IndexAvailableModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        public IList<Car> Car { get; set; } = default!;

        public void OnGet()
        {
            ViewData["CurrentUserName"] = Request.Cookies["CurrentUserName"];
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
            Car = carRepo.GetAllAvailable().ToList();
        }
    }
}
    
