using Ixy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Application.Service
{
    public interface IUserService
    {
        Task<User> Get(int id);
        Task<bool> Add(User entity);
    }
}
