using Ixy.Core.Interface;
using Ixy.Core.Model;
using Ixy.Infrastructure.Interface;

namespace Ixy.Infrastructure.Repository
{
    public class MenuRepository : BaseRepository<MenuItem>, IMenuRepository
    {
        public MenuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
