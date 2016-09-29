using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;

namespace Ixy.Infrastructure.Interface
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
