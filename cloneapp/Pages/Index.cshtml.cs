using cloneapp.Data;
using cloneapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace cloneapp.Pages;

public class IndexModel : PageModel
{	
	public class ArticleProps
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public string UserName { get; set; }
	}

	public const int MaxQueryOutput = 5;

	private DataContext dbContext;
	private UserManager<IdentityUser> userManager;
	public List<Category> categories;
	
	public IEnumerable<ArticleProps> articleProps;
	public int lastArticleId;

	public IndexModel(DataContext dbContext, UserManager<IdentityUser> userManager)
	{
		this.dbContext = dbContext;
		this.userManager = userManager;
	}

	public void OnGet()
	{
        categories = dbContext.Categories.AsNoTracking().ToList();
		articleProps = GetArticlePropsArray();
		lastArticleId = articleProps.Last().ArticleId;
	}

	public IActionResult OnGetCategoryArticlesProps(string category, int lastArticleId)
	{
        var array = GetArticlePropsArray(category, lastArticleId);

		return new JsonResult(new { contents = array, lastArticleId = array.Last().ArticleId });
    }

	public IEnumerable<ArticleProps> GetArticlePropsArray()
	{
		return GetArticlePropsQuery().ToArray().Take(MaxQueryOutput);
	}
	
	public IEnumerable<ArticleProps> GetArticlePropsArray(string category, int lastArticleId)
	{
		return GetArticlePropsQuery(lastArticleId).Where(article => article.Category == category).Take(MaxQueryOutput).ToArray();
	}

	public IQueryable<ArticleProps> GetArticlePropsQuery(int lastArticleId = 0)
	{
        return dbContext.Articles.AsNoTracking().Join(dbContext.ArticleCategories, article => article.ArticleId, categories => categories.ArticleId,
			   (article, categories) => new ArticleProps { ArticleId = article.ArticleId, Title = article.Title!, UserName = article.UserName, Category = categories.CategoryName }).
			   Where(article => article.ArticleId > lastArticleId);
	}

	public string ArticleLink(int articleId)
	{
		return "/GetArticle?articleId=" + articleId;
	}
}