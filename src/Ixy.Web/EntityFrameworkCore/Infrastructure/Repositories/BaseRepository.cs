using Ixy.EntityFrameworkCore.Models;
using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Ixy.EntityFrameworkCore.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ixy.EntityFrameworkCore.Infrastructure.Repositories
{
    public abstract class BaseRepository<TAggregateRoot> : 
        IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public readonly IQueryable<TAggregateRoot> _entities;

        public BaseRepository(IDbContext dbContext)
        {
            _entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> Get(string id)
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
