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
    public class PostService : IPostService
    {
        private IUnitOfWork _unitOfWork;
        private IPostRepository _repository;

        public PostService(IUnitOfWork unitOfWork, IPostRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public async Task<bool> AddAsync(Post entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public Task<bool> DeleteAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Post> GetAsync(string id)
        {
            var ps = await _repository.GetAsync(t => t.Id == id);
            return ps.FirstOrDefault();
        }

        public Task<List<Post>> GetAsync(int startPage, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
