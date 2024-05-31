using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloneapp.Models;

[Table("Categories")]
public class Category
{
	[Key]
	[Column("Id")]
	public int Id { get; set; }

	[Column("CategoryName")]
	public string CategoryName { get; set; }
}
