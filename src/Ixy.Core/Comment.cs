using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Core
{
    public class Comment : BaseEntity
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string Ip { get; set; }
        public string PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
