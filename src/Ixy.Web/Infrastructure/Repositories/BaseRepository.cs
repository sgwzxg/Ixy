using Ixy.Core.Interfaces;
using Ixy.Core.Models;
using Ixy.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Repositories
{
    public abstract class BaseRepository<TAggregateRoot> :
        IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public readonly IQueryable<TAggregateRoot> _entities;

        public BaseRepository(IDbContext dbContext)
        {
            _entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return _entities;
        }

        public async Task<List<TAggregateRoot>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public IQueryable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return _entities;
        }

        public async Task<List<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }


        public IQueryable<TAggregateRoot> LoadPageList(int startPage, int pageSize, Expression<Func<TAggregateRoot, bool>> where, Expression<Func<TAggregateRoot, object>> order)
        {
            var result = _entities;
            if (where != null)
                result = result.Where(where);
            if (order != null)
                result = result.OrderBy(order);
            else
                result = result.OrderBy(m => m.Id);
            //rowCount = result.Count();
            return result.Skip((startPage - 1) * pageSize).Take(pageSize);
        }


    }
}
