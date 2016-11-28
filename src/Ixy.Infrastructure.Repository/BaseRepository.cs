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

        public IQueryable<T> Get()
        {
            return Get(null);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Get(predicate, null, SortType.Asc, 0);
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            int size)
        {
            return Get(predicate, null, SortType.Asc, size);
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            int startPage, int pageSize)
        {
            return Get(predicate, null, startPage, pageSize);
        }

        public IQueryable<T> Get(
            Expression<Func<T, object>> order,
            SortType sortType, int size)
        {
            return Get(null, order, SortType.Asc, size);
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> order,
            int startPage, int pageSize)
        {
            return Get(predicate, order, SortType.Asc, startPage, pageSize);
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> order,
            SortType sortType, int size)
        {
            var entities = _entities;
            if (predicate != null)
            {
                entities = entities.Where(predicate);
            }

            if (order == null)
            {
                order = t => t.Id;
            }

            if (sortType == SortType.Asc)
            {
                entities = entities.OrderBy(order);
            }
            else
            {
                entities = entities.OrderByDescending(order);
            }

            if (size > 0)
            {
                entities = entities.Take(size);
            }

            return entities;
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> order,
            SortType sortType, int startPage, int pageSize)
        {
            var result = _entities;

            if (predicate != null)
                result = result.Where(predicate);
            if (order != null)
                order = t => t.Id;
            if (sortType == SortType.Asc)
                result = result.OrderBy(order);
            else
                result = result.OrderByDescending(order);

            return result.Skip((startPage - 1) * pageSize).Take(pageSize);
        }

        public T GetById(string id)
        {
            return Get(t => t.Id == id).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Get(t => t.Id == id).FirstOrDefaultAsync();
        }

    }
}
