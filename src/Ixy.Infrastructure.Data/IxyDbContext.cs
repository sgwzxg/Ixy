using Ixy.Core;
using Ixy.Core.Identity;
using Ixy.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ixy.Infrastructure.Data
{
    public class IxyDbContext : IdentityDbContext<IxyUser, IxyRole, string>, IDbContext
    {
        public IxyDbContext(DbContextOptions<IxyDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<IxyUser>().ToTable("IxyUser");
            //builder.Entity<IdentityRole>().ToTable("IxyRole");
            //builder.Entity<IdentityUserRole<string>>().ToTable("IxyUserRole");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("IxyRole");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("IxyUserLogin");


        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
