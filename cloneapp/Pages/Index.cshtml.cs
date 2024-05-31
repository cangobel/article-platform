using cloneapp.Data;
using cloneapp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cloneapp.Pages;

public class IndexModel : PageModel
{
	private DataContext dbContext;
	public List<Category> categories;

	public IndexModel(DataContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public void OnGet()
	{
		categories = dbContext.Categories.ToList();
	}
}