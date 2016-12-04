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
        T GetById(string id);
        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int topSize);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int topSize);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, object>> order, SortType sortType, int topSize);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int topSize);

        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int topSize);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int topSize);
        IEnumerable<T> Get(Expression<Func<T, object>> order, SortType sortType, int topSize);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int topSize);

        Task<Tuple<IEnumerable<T>, int>> GetAsync(int startPage, int pageSize);
        Task<Tuple<IEnumerable<T>, int>> GetAsync(Expression<Func<T, bool>> predicate, int startPage, int pageSize);
        Task<Tuple<IEnumerable<T>, int>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int startPage, int pageSize);
        Task<Tuple<IEnumerable<T>, int>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize);

        Tuple<IEnumerable<T>, int> Get(int startPage, int pageSize);
        Tuple<IEnumerable<T>, int> Get(Expression<Func<T, bool>> predicate, int startPage, int pageSize);
        Tuple<IEnumerable<T>, int> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int startPage, int pageSize);
        Tuple<IEnumerable<T>, int> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize);

        Task<bool> AddAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> DeleteAsync(T entity);

        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(T entity);
    }
}
