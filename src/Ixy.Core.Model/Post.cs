﻿using Ixy.Core.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Core.Model
{
    public class Post : IAggregateRoot
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public bool Published { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

    }
}
