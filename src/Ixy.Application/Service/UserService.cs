using Ixy.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Domain.Entities;
using Ixy.Infrastructure.Interface;
using Ixy.Infrastructure.Repository.Interface;

namespace Ixy.Application.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userReportRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userReportRepository;
        }

        public async Task<bool> Add(User entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<User> Get(int id)
        {
            return _userRepository.Get(id).FirstOrDefault();
        }
    }
}
