using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Core.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreateDateTime { get; set; }

        public List<Post> Posts { get; set; }

    }
}
