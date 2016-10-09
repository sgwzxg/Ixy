using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ixy.EntityFrameworkCore.Infrastructure
{
    public class IxyDbContext : DbContext, IDbContext
    {
        public IxyDbContext(DbContextOptions<IxyDbContext> options)
           : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
    }
}
