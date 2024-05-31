using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace cloneapp.Pages;

public class SignUpModel : PageModel
{
	private readonly UserManager<IdentityUser> _userManager;

	public SignUpModel(UserManager<IdentityUser> userManager)
	{
		_userManager = userManager;
	}

	[BindProperty]
	[Required]
	public string UserName { get; set; }

	[BindProperty]
	[Required]
	[EmailAddress]
	public string Email { get; set; }

	[BindProperty]
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[BindProperty]
	[Required]
	[DataType(DataType.Password)]
	[Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
	public string ConfirmPassword { get; set; }

	public IdentityResult IdentityResult { get; set; }


	public void OnGet()
	{

	}

	public void OnPost()
	{
		IdentityResult result;

		if (ModelState.IsValid)
		{
			IdentityUser user = new() { UserName = UserName, Email = Email };
			result = _userManager.CreateAsync(user, Password).Result;

			IdentityResult = result;
		}
	}

}
