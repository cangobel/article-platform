using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloneapp.Models;

[Table("UserImages")]
public class UserImage
{
	[Key]
	[Column("UserId")]
	public string UserId { get; set; }

	[Column("ImagePath")]
	public string ImagePath { get; set; }
}


