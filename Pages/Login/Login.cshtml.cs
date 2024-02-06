using Friberg_car_rentals_v2.Data;
using Microsoft.AspNetCore.Http;
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

        public IActionResult OnPost(string email, string password)
        {
            var user = customerRepo.GetByEmail(email);
            
            if (user == null)
            {
                var adminUser = adminRepo.GetByEmail(email);
                
                if (adminUser != null && adminUser.Password == password)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTimeOffset.UtcNow.AddHours(1);
                    Response.Cookies.Append("CurrentAdmin", $"{adminUser.FirstName} {adminUser.LastName}", options); //Creates admin-cookie
                    
                    return RedirectToPage("/Index");
                }
            }

            if (user != null && user.Password == password)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTimeOffset.UtcNow.AddHours(1);
                Response.Cookies.Append("CurrentUserName", $"{user.FirstName} {user.LastName}", options); //Creates user-cookies
                Response.Cookies.Append("CurrentUserId", user.Id.ToString(), options);                
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
