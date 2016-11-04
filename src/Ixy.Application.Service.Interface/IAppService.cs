using Ixy.Core.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Application.Service.Interface
{
    public interface IAppService<T> where T : IAggregateRoot
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task<bool> AddAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<List<T>> GetAsync(int startPage, int pageSize);
        Task<bool> DeleteAsync(T entity);
    }
}
