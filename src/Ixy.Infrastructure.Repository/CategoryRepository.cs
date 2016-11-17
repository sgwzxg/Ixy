using Ixy.Core.Interface;
using Ixy.Core.Model;
using Ixy.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
