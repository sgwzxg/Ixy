using Ixy.Application.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Core.Model;
using Ixy.Infrastructure.Interface;
using Ixy.Core.Interface;

namespace Ixy.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private ICategoryRepository _repository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public async Task<bool> AddAsync(Category entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public Task<bool> DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetAsync(string id)
        {
            var ps = await _repository.GetAsync(t => t.Id == id);
            return ps.FirstOrDefault();
        }

        public Task<List<Category>> GetAsync(int startPage, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
