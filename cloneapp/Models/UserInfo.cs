using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloneapp.Models;

[Table("UserInfos")]
public class UserInfo
{
	[Key]
	[Column("UserId")]
	public string UserId { get; set; }

	[Column("Information")]
	public string Information { get; set; }
}
