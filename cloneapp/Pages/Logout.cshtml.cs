using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cloneapp.Pages
{
    public class LogoutModel : PageModel
    {
        SignInManager<IdentityUser> _signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            _signInManager.SignOutAsync();

            return RedirectToPage("/Index");
        }
    }
}
