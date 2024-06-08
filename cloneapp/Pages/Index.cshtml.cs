using cloneapp.Data;
using cloneapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

	private DataContext dbContext;
	private UserManager<IdentityUser> userManager;
	public List<Category> categories;
	public List<ArticleProps> articleProps;

	public IndexModel(DataContext dbContext, UserManager<IdentityUser> userManager)
	{
		this.dbContext = dbContext;
		this.userManager = userManager;
	}

	public void OnGet()
	{
		categories = dbContext.Categories.ToList();
		articleProps = GetArticlePropsList();
	}

	public IActionResult OnPostCategoryArticles(string category)
	{
        var list = GetArticlePropsList(category);

		return new JsonResult(new { content = list });
    }

	public List<ArticleProps> GetArticlePropsList()
	{
		return GetArticlePropsQuery().ToList();
	}
	
	public List<ArticleProps> GetArticlePropsList(string category)
	{
		return GetArticlePropsQuery().Where(article => article.Category == category).ToList();
	}

	public IQueryable<ArticleProps> GetArticlePropsQuery()
	{
		return dbContext.Articles.Join(dbContext.ArticleCategories, article => article.ArticleId, categories => categories.ArticleId, (article, categories) =>
				new ArticleProps { ArticleId = article.ArticleId, Title = article.Title!, UserName = article.UserName, Category = categories.CategoryName });
	}

	public string ArticleLink(int articleId)
	{
		return "/GetArticle?articleId=" + articleId;
	}
}