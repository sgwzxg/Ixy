using Ixy.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ixy.Applications.Services
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<MenuItem> GetAsync(string id);
        Task<bool> AddAsync(MenuItem entity);
        Task<List<MenuItem>> GetByParentAsync(string parentId, int startPageIndex, int pageSize);
        Task<bool> DeleteAsync(MenuItem entity);
    }
}
