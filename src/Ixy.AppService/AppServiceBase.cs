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

namespace Ixy.AppService
{
    public abstract class AppServiceBase<T> where T : class, IAggregateRoot
    {
        protected IUnitOfWork _unitOfWork;
        protected IRepository<T> _repository;

        public async Task<T> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> EditAsync(T entity)
        {
            _unitOfWork.RegisterDirty(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _unitOfWork.RegisterDeleted(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await GetAsync(null);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAsync(predicate, 0);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int size)
        {
            return await GetAsync(predicate, t => t.Id, SortType.Asc, size);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int size)
        {
            return await GetAsync(predicate, order, SortType.Asc, size);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int size)
        {
            return await _repository.Get(predicate, order, sortType, size).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, object>> order, SortType sortType, int size)
        {
            return await GetAsync(null, order, sortType, size);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int startPage, int pageSize)
        {
            return await GetAsync(predicate, t => t.Id, SortType.Asc, startPage, pageSize);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int startPage, int pageSize)
        {
            return await GetAsync(predicate, order, SortType.Asc, startPage, pageSize);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize)
        {
            return await _repository.Get(predicate, order, sortType, startPage, pageSize).ToListAsync();
        }
    }
}
