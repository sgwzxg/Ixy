using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ixy.Data.Models;
namespace Ixy.EntityFrameworkCore.Infrastructure
{
    public class IxyDbContext : DbContext, IDbContext
    {
        public IxyDbContext(DbContextOptions<IxyDbContext> options)
           : base(options)
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
