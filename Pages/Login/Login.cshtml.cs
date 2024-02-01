using Friberg_car_rentals_v2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_car_rentals_v2.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IAdmin adminRepo;

        public LoginModel(ICustomer customerRepo, IAdmin adminRepo)
        {
            this.customerRepo = customerRepo;
            this.adminRepo = adminRepo;
        }
        public void OnGet()
        {
        }

        //public IActionResult OnPost(string email, string password)
        //{
        //    var user = customerRepo.GetByEmail(email);

        //    if (user != null && user.Password == password)
        //    {
        //        // Authentication successful
        //        HttpContext.Session.SetString("Username", user.Username);
        //        return RedirectToPage("/Index"); // Redirect to the home page or another protected page
        //    }
        //}
    }
}
