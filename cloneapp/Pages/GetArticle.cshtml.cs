using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cloneapp.Data;
using cloneapp.Models;

namespace cloneapp.Pages
{
    public class GetArticleModel : PageModel
    {
        DataContext _dataContext;
        public Article article;
        public string content;

		public GetArticleModel(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

		public IActionResult OnGet(int? articleId)
        {
            if(articleId != null)
            {
                article = _dataContext.Articles.Where(article => article.ArticleId == articleId).FirstOrDefault()!;
                if(article != null)
                {
                    content = "<h1>" + article.Title + "</h1>" + article.Content;
                    return Page();
                }
            }
            return NotFound();
        }
    }
}
