using cloneapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cloneapp.Data;

public class DataContext : DbContext
{	
	public DbSet<Article> Articles => Set<Article>();

	public DbSet<UserImage> UserImages => Set<UserImage>();

	public DbSet<UserInfo> UserInfos => Set<UserInfo>();

	public DbSet<ArticleCategory> ArticleCategories => Set<ArticleCategory>();

	public DbSet<Category> Categories => Set<Category>();

	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}
}
