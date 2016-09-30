using Ixy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ixy.Infrastructure.Repository.Interface
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        IQueryable<TAggregateRoot> Get(int id);

        //Task<IQueryable<TAggregateRoot>> GetAsync(int id);

        IQueryable<TAggregateRoot> GetAll();

        IQueryable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> predicate);
    }
}
