using System;

namespace Ixy.Core.Models
{
    public class Post : IAggregateRoot
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime PostDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public string PostId { get; set; }
    }
}
