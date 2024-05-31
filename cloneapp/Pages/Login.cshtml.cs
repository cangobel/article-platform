using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace cloneapp.Pages;

public class LoginModel : PageModel
{
	private readonly SignInManager<IdentityUser> _signInManager;

	public LoginModel(SignInManager<IdentityUser> signInManager)
	{
		_signInManager = signInManager;
	}

	[Required]
	[BindProperty]
	public string UserName { get; set; }

	[Required]
	[DataType(DataType.Password)]
	[BindProperty]
	public string Password { get; set; }

	[Display(Name = "Remember Me")]
	[BindProperty]
	public bool RememberMe { get; set; }

	public void OnGet()
	{
	}

	public IActionResult OnPost()
	{
		if (ModelState.IsValid)
		{
			var result = _signInManager.PasswordSignInAsync(UserName, Password, RememberMe, false).Result;
			if (result.Succeeded)
			{
				var user = _signInManager.UserManager.FindByNameAsync(UserName).Result;

				return RedirectToPage("/User/Index");
			}
		}

		return Page();
	}

}
