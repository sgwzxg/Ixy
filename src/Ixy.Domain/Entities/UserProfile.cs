using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Domain.Entities
{
    public class UserProfile : IAggregateRoot
    {
        public int Id { get; set; }
    }
}
