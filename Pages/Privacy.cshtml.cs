using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_car_rentals_v2.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
        }
    }

}
