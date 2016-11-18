using Ixy.Core.Interface;
using Ixy.Core;
using Ixy.Infrastructure.Interface;
using Ixy.Infrastructure.Repository.Interface;

namespace Ixy.Infrastructure.Repository
{
    public class MenuRepository : BaseRepository<MenuItem>, IMenuRepository
    {
        public MenuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
