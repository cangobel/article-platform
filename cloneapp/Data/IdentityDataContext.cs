using cloneapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cloneapp.Data;

public class IdentityDataContext : IdentityDbContext
{	
	public IdentityDataContext(DbContextOptions<IdentityDataContext> dbContextOptions) : base(dbContextOptions)
	{

	}
}
