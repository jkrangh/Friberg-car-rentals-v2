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
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginModel(ICustomer customerRepo, IAdmin adminRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.customerRepo = customerRepo;
            this.adminRepo = adminRepo;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string email, string password)
        {
            var user = customerRepo.GetByEmail(email);
            //if (user == null)
            //{
            //    var adminUser = adminRepo.GetByEmail(email) as ICustomer;
            //}

            if (user != null && user.Password == password)
            {
                CookieOptions options = new CookieOptions(); //Fredriks
                options.Expires = DateTimeOffset.UtcNow.AddHours(1);
                httpContextAccessor.HttpContext.Response.Cookies.Append("CurrentUserName", $"Welcome {user.FirstName} {user.LastName}", options);
                //httpContextAccessor.HttpContext.Response.Cookies.Append("CurrentUserId", user.Id.ToString(), options);

                return RedirectToPage("/Cars/Index");
            }
            return Page();
        }
    }
}
