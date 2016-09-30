using Ixy.Domain;
using Ixy.Infrastructure.Interface;
using Ixy.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Repository
{
    public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public readonly IQueryable<TAggregateRoot> _entities;

        public BaseRepository(IDbContext dbContext)
        {
            _entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> Get(int id)
        {
            
            return _entities.Where(t => t.Id == id);
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return _entities;
        }

        public IQueryable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return _entities;
        }
    }
}
