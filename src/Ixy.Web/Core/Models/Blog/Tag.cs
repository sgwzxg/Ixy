using System;

namespace Ixy.Core.Models
{
    public class Tag : IAggregateRoot
    {
        public Tag()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string PostId { get; set; }
    }
}
