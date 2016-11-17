using Ixy.Core.Interface;
using Ixy.Core.Model;
using Ixy.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
