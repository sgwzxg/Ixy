using Ixy.Core;
using Ixy.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ixy.AppService.Interface
{
    public interface IAppService<T> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int size);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int size);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int size);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, object>> order, SortType sortType, int size);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int startPage, int pageSize);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int startPage, int pageSize);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize);

        Task<bool> AddAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
