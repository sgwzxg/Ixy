using Ixy.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        public void RegisterNew<TEntity>(TEntity entity)
        where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void RegisterDirty<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void RegisterClean<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;
        }

        public void RegisterDeleted<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
