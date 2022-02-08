﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    [Serializable]
    public class PostReacted
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public PostReaction Reaction { get; set; }
        public PostReacted() { }
    }
}
