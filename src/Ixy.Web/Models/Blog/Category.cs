using Ixy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Models
{
    public class Category : IAggregateRoot
    {
        public Category()
        {

            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string PostId { get; set; }
    }
}
