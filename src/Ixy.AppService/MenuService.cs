using Ixy.AppService.Interface;
using Ixy.Core.Interface;
using Ixy.Core;
using Ixy.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Infrastructure.Repository.Interface;

namespace Ixy.AppService
{
    public class MenuService : AppServiceBase<MenuItem>, IMenuService
    { 
        public MenuService(IUnitOfWork unitOfWork, IMenuRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

    }
}
