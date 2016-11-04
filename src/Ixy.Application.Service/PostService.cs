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
    public class PostService : IPostService
    {
        private IUnitOfWork _unitOfWork;
        private IPostRepository _repository;

        public PostService(IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = postRepository;
        }

        public Task<bool> AddAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAsync(int startPage, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
