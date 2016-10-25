using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Ixy.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ixy.EntityFrameworkCore.Infrastructure
{
    public class IxySysDbContext : IdentityDbContext<IxyUser>, IDbContext
    {
        public IxySysDbContext(DbContextOptions<IxySysDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
