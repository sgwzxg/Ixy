﻿using Ixy.Core.Interface;
using Ixy.Core;
using Ixy.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ixy.Infrastructure.Repository.Interface;

namespace Ixy.Infrastructure.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
    
}
