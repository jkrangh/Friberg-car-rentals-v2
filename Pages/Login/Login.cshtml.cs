using Friberg_car_rentals_v2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_car_rentals_v2.Pages.Login
{
    public class LoginModel : PageModel
    {
        public LoginModel(ICustomer customerRepo, IAdmin adminRepo)
        {
            
        }
        public void OnGet()
        {
        }

        //public IActionResult OnPost(string username, string password)
        //{
        //    var user = 
        //}
    }
}
