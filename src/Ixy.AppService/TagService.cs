using Ixy.AppService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Core;
using Ixy.Infrastructure.Interface;
using Ixy.Core.Interface;
using Ixy.Infrastructure.Repository.Interface;

namespace Ixy.AppService
{
    public class TagService : ITagService
    {
        private IUnitOfWork _unitOfWork;
        private ITagRepository _repository;

        public TagService(IUnitOfWork unitOfWork, ITagRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public async Task<bool> AddAsync(Tag entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public Task<bool> DeleteAsync(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Tag entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tag> GetAsync(string id)
        {
            var ps = await _repository.GetAsync(t => t.Id == id);
            return ps.FirstOrDefault();
        }

        public Task<List<Tag>> GetAsync(int startPage, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
