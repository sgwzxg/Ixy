using System.Threading.Tasks;

namespace Ixy.EntityFrameworkCore.Infrastructure.Interfaces
{
    /// <summary>
    /// http://martinfowler.com/eaaCatalog/unitOfWork.html
    /// </summary>
    public interface IUnitOfWork
    {
        void RegisterNew<TEntity>(TEntity entity) where TEntity : class;
        void RegisterDirty<TEntity>(TEntity entity) where TEntity : class;
        void RegisterClean<TEntity>(TEntity entity) where TEntity : class;
        void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> CommitAsync();
        void Rollback();
    }
}
