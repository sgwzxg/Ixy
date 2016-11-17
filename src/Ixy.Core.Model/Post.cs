using Ixy.Core.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Core.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public bool Published { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
