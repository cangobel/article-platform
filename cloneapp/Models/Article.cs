using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloneapp.Models;

public class Article
{
	[Key]
	[Column("ArticleId")]
	public int ArticleId { get; set; }

	[Column("UserName")]
	public string UserName { get; set; }

	[Column("Title")]
	public string? Title { get; set; }

	[Column("Content")]
	public string? Content { get; set; }

	[Column("ReleaseDate")]
	public DateTime? ReleaseDate { get; set; }

	[Column("isReleased")]
	public bool isReleased { get; set; }
}
