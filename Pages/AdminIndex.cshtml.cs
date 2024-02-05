using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_car_rentals_v2.Pages
{
    public class AdminIndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CurrentUserName"] = Request.Cookies["CurrentUserName"];
        }
    }
}
