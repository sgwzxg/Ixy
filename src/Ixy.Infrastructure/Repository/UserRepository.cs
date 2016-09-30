using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Infrastructure.Repository.Interface;
using Ixy.Domain.Entities;
using Ixy.Infrastructure.Interface;

namespace Ixy.Infrastructure.Repository
{
    public class UserRepository :BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext)
            : base(dbContext)
        { }
    }
}
