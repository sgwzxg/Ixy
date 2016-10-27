using Ixy.Core.Interfaces;
using Ixy.Core.Models;
using Ixy.Infrastructure.Interfaces;

namespace Ixy.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<MenuItem>, IMenuRepository
    {
        public MenuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
