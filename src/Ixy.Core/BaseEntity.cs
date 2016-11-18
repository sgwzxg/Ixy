using Ixy.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Core
{
    public abstract class BaseEntity : IAggregateRoot
    {
        public string Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }

        private static bool IsTransient(BaseEntity obj)
        {
            return obj != null && Equals(obj.Id, Guid.Empty.ToString());
        }
    }
}
