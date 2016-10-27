using System.Collections.Generic;
using System.Threading.Tasks;
using Ixy.Core.Models;
namespace Ixy.Application.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<MenuItem> GetAsync(string id);
        Task<bool> AddAsync(MenuItem entity);
        Task<bool> EditAsync(MenuItem entity);
        Task<List<MenuItem>> GetByParentAsync(string parentId, int startPageIndex, int pageSize);
        Task<bool> DeleteAsync(MenuItem entity);
    }
}
