using Ixy.Application.Service.Interface;
using Ixy.Core.Interface;
using Ixy.Core.Model;
using Ixy.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Application.Service
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;
        private IMenuRepository _repository;

        public MenuService(IUnitOfWork unitOfWork, IMenuRepository menuRepository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = menuRepository;
        }

        public async Task<MenuItem> GetAsync(string id)
        {
            var entity = await _repository.GetAsync(t => t.Id == id);
            return entity.FirstOrDefault();
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<MenuItem>> GetByParentAsync(string parentId, int startPageIndex, int pageSize)
        {
            return await _repository.LoadPageList(startPageIndex, pageSize, t => t.ParentId == parentId, t => t.Serial).ToListAsync();
        }

        public async Task<bool> AddAsync(MenuItem entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(MenuItem entity)
        {
            _unitOfWork.RegisterDeleted(entity);
            return await _unitOfWork.CommitAsync();

        }

        public async Task<bool> EditAsync(MenuItem entity)
        {
            _unitOfWork.RegisterDirty(entity);
            return await _unitOfWork.CommitAsync();
        }
    }
}
