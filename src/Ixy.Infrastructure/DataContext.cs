using Ixy.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Infrastructure
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }
        
    }
}
