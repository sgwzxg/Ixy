using Ixy.EntityFrameworkCore.Infrastructure.Interfaces;
using Ixy.EntityFrameworkCore.Infrastructure.Repositories.Interfaces;
using Ixy.Models.Identity;
using System.Linq;
using System.Threading.Tasks;
//using Ixy.Domain.Entities;

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

        public async Task<bool> Add(IxyUser entity)
        {
            _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<IxyUser> Get(string id)
        {
            return null;
            //return _userRepository.Get(id).FirstOrDefault();
        }
    }
}
