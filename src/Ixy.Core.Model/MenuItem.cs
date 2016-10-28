﻿using Ixy.Core.Model.Interface;

namespace Ixy.Core.Model
{
    public class MenuItem : IAggregateRoot
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public int Serial { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }

    public class TreeNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
    }
}
