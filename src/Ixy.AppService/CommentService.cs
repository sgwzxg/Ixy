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
    public class CommentService :   AppServiceBase<Comment>, ICommentService
    {
        
        public CommentService(IUnitOfWork unitOfWork, ICommentRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }
        
    }
}
