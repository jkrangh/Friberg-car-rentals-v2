using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Friberg_car_rentals_v2.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CurrentUserName"] = Request.Cookies["CurrentUserName"];
            ViewData["CurrentUserId"] = Request.Cookies["CurrentUserId"];
            ViewData["CurrentAdmin"] = Request.Cookies["CurrentAdmin"];
        }

        public IActionResult OnPost()
        {
            Response.Cookies.Delete("CurrentUserName"); //Deletes user cookies on log out
            Response.Cookies.Delete("CurrentAdmin");
            Response.Cookies.Delete("CurrentUserId");
            return RedirectToPage("/Index");
        }
    }
}
