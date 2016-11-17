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
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;
        private ICommentRepository _repository;

        public CommentService(IUnitOfWork unitOfWork, ICommentRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public async Task<bool> AddAsync(Comment entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public Task<bool> DeleteAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Comment> GetAsync(string id)
        {
            var ps = await _repository.GetAsync(t => t.Id == id);
            return ps.FirstOrDefault();
        }

        public Task<List<Comment>> GetAsync(int startPage, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
