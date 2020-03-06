using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Post.Review
{
    public class ReviewEntity
    {
        public PostEntity PostEntity { get; set; }
        public string Text { get; set; }
        public int Version { get; set; }
        public DateTime DateTime { get; set; }
    }
}
