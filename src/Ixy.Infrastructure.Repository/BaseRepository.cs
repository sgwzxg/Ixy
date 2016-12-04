using Ixy.Core;
using Ixy.Core.Interface;
using Ixy.Infrastructure.Interface;
using Ixy.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        public readonly IQueryable<T> _entities;

        public BaseRepository(IDbContext dbContext)
        {
            _entities = dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> order,
            SortType sortType, int topSize = 0)
        {
            var entities = _entities;
            if (predicate != null)
            {
                entities = entities.Where(predicate);
            }

            if (order != null)
            {
                if (sortType == SortType.Asc)
                {
                    entities = entities.OrderBy(order);
                }
                else if (sortType == SortType.Desc)
                {
                    entities = entities.OrderByDescending(order);
                }
            }

            if (topSize > 0)
            {
                entities = entities.Take(topSize);
            }

            return entities;
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> order,
            SortType sortType, int startPage, int pageSize, out int total)
        {
            var result = _entities;

            if (predicate != null)
            {
                result = result.Where(predicate);
            }

            total = result.Count();

            if (order != null)
            {
                if (sortType == SortType.Asc)
                {
                    result = result.OrderBy(order);
                }
                else if (sortType == SortType.Desc)
                {
                    result = result.OrderByDescending(order);
                }
            }

            return result.Skip((startPage - 1) * pageSize).Take(pageSize);
        }

        public T GetById(string id)
        {

            return Get(t => t.Id == id, null, SortType.Default).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Get(t => t.Id == id, null, SortType.Default).FirstOrDefaultAsync();
        }

    }
}
