using cloneapp.Data;
using cloneapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cloneapp.Pages.User;

[Authorize(Roles = "admin")]
public class IndexModel : PageModel
{
    public IndexModel()
    {
    }

    public IActionResult OnGet()
    {
        return Page();
    }

}
