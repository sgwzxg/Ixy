using Ixy.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Data.Models;
using System.Linq.Expressions;
using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;

namespace Ixy.EntityFrameworkCore.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<MenuItem>, IMenuRepository
    {
        public MenuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
