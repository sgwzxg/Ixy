﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ixy.Core.Interface;
namespace Ixy.Infrastructure.Repository.Interface
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        IQueryable<TAggregateRoot> GetAll();

        Task<List<TAggregateRoot>> GetAllAsync();
        
        IQueryable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> predicate);

        Task<List<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>> predicate);

        IQueryable<TAggregateRoot> LoadPageList(int startPage, int pageSize, Expression<Func<TAggregateRoot, bool>> where, Expression<Func<TAggregateRoot, object>> order);
    }
}