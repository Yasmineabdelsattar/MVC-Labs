using lab7_MVC_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab7_MVC_Identity.Context;

public class SystemContext: IdentityDbContext<CustomUser>
{
	public SystemContext(DbContextOptions<SystemContext> options): base (options)
	{}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

        builder.Entity<CustomUser>().ToTable("Users");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims");
    }
}
