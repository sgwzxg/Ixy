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

        public T GetById(string id)
        {
            return _repository.GetById(id);
        }

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

        public bool Add(T entity)
        {
            _unitOfWork.RegisterNew(entity);
            return _unitOfWork.Commit();
        }

        public bool Edit(T entity)
        {
            _unitOfWork.RegisterDirty(entity);
            return _unitOfWork.Commit();
        }

        public bool Delete(T entity)
        {
            _unitOfWork.RegisterDeleted(entity);
            return _unitOfWork.Commit();
        }

        private IQueryable<T> GetData(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int topSize)
        {
            return _repository.Get(predicate, order, sortType, topSize);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int topSize)
        {
            return GetData(predicate, order, sortType, topSize).ToList();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int topSize)
        {
            return await GetData(predicate, order, sortType, topSize).ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, object>> order, SortType sortType, int topSize)
        {
            return Get(null, order, sortType, topSize);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, object>> order, SortType sortType, int topSize)
        {
            return await GetAsync(null, order, sortType, topSize);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int topSize)
        {
            return Get(predicate, order, SortType.Default, topSize);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int topSize)
        {
            return await GetAsync(predicate, order, SortType.Default, topSize);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int topSize)
        {
            return Get(predicate, null, SortType.Default, topSize);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int topSize)
        {
            return await GetAsync(predicate, null, SortType.Default, topSize);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Get(predicate, null, SortType.Default, 0);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAsync(predicate, null, SortType.Default, 0);
        }

        public IEnumerable<T> Get()
        {
            return Get(null, null, SortType.Default, 0);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await GetAsync(null, null, SortType.Default, 0);
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAsync(int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = await _repository.Get(null, null, SortType.Default, startPage, pageSize, out total).ToListAsync();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAsync(Expression<Func<T, bool>> predicate, int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = await _repository.Get(predicate, null, SortType.Default, startPage, pageSize, out total).ToListAsync();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = await _repository.Get(predicate, order, SortType.Default, startPage, pageSize, out total).ToListAsync();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = await _repository.Get(predicate, order, sortType, startPage, pageSize, out total).ToListAsync();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }


        public Tuple<IEnumerable<T>, int> Get(int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = _repository.Get(null, null, SortType.Default, startPage, pageSize, out total).ToList();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }

        public Tuple<IEnumerable<T>, int> Get(Expression<Func<T, bool>> predicate, int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = _repository.Get(predicate, null, SortType.Default, startPage, pageSize, out total).ToList();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }

        public Tuple<IEnumerable<T>, int> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = _repository.Get(predicate, order, SortType.Default, startPage, pageSize, out total).ToList();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }

        public Tuple<IEnumerable<T>, int> Get(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order, SortType sortType, int startPage, int pageSize)
        {
            int total = 0;

            var dataRows = _repository.Get(predicate, order, sortType, startPage, pageSize, out total).ToList();

            return new Tuple<IEnumerable<T>, int>(dataRows, total);
        }
    }
}
