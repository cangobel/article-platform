using cloneapp.Data;
using cloneapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cloneapp.Pages;

[IgnoreAntiforgeryToken(Order = 1001)]
[Authorize(Roles = "admin, user")]
public class WriteArticleModel : PageModel
{
	private DataContext _dbContext;
	private UserManager<IdentityUser> _userManager;
	private readonly IWebHostEnvironment _environment;

	public string userName => HttpContext.User.Identity!.Name!;

	public Article article { get; set; }

	public WriteArticleModel(DataContext dbContext, UserManager<IdentityUser> userManager, IWebHostEnvironment environment)
	{
		this._dbContext = dbContext;
		_userManager = userManager;
		_environment = environment;
	}

	public IActionResult OnGet(int? articleId)
	{
        if (articleId == null)
		{
			return NotFound();
		}
		else
		{
			Article article = _dbContext.Articles.Where(article => article.ArticleId == articleId).FirstOrDefault()!;
			if (article == null)
			{
				return NotFound();
			}
			else
			{
				this.article = article;
			}
		}
		return Page();
	}

	public IActionResult OnPostSaveArticle(string title, string content, int articleId)
	{
		Article article = _dbContext.Articles.Where(article => article.ArticleId == articleId && article.UserName == userName).FirstOrDefault();

		if (article != null)
		{
			article.Title = title;
			article.Content = content;
			_dbContext.SaveChanges();
		}

		return new JsonResult("");
	}

	public IActionResult OnPostUploadImage()
	{
		try
		{
			var file = Request.Form.Files[0];
			var uploads = Path.Combine(_environment.WebRootPath, "uploads");
			var filePath = Path.Combine(uploads, file.FileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(fileStream);
			}

			// Resmin URL'sini Tinymce'e dön
			return new JsonResult(new { location = "/uploads/" + file.FileName });
		}
		catch (Exception ex)
		{
			// Hata durumunda uygun yanýtý dön
			return BadRequest(new { message = ex.Message });
		}
	}

	public IActionResult OnPostGetArticle(int articleId)
	{	
		Article article = _dbContext.Articles.Where(article => article.ArticleId == articleId).FirstOrDefault()!;
		object result;
		if (article != null)
		{
            result = new { content = article.Content, title = article.Title };
		}
		else
		{
			result = new();
		}
		return new JsonResult(result);
    }
}
