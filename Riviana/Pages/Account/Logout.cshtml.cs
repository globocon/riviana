using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Riviana.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public LogoutModel()
        {

        }

        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync();
            return Page(); // or wherever you want to go after logout
        }
    }
}
