
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ixy.Core.Interface;
using Ixy.Core;

namespace Ixy.Infrastructure.Repository.Interface
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        T GetById(string id);

        Task<T> GetByIdAsync(string id);

        IQueryable<T> Get();

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int size);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize);
    }
}
