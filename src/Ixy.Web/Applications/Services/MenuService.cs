using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Data.Models;
using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Ixy.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ixy.Applications.Services
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;
        private IMenuRepository _repository;

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
    }
}
