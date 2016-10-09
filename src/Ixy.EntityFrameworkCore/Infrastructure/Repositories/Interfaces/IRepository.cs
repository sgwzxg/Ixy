using Ixy.EntityFrameworkCore.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ixy.EntityFrameworkCore.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        IQueryable<TAggregateRoot> Get(string id);

        //Task<IQueryable<TAggregateRoot>> GetAsync(int id);

        IQueryable<TAggregateRoot> GetAll();

        IQueryable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> predicate);
    }
}
