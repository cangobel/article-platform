using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloneapp.Models;

[Table("ArticleCategories")]
public class ArticleCategory
{
	[Key]
	[Column("Id")]
	public int Id { get; set; }

	[Column("CategoryName")]
	public string CategoryName { get; set; }

	[Column("ArticleId")]
	public int ArticleId { get; set; }
}
