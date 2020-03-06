using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Post.Review.Classification
{
    public class ClassificationEntity
    {
        public ReviewEntity Review { get; set; }
        public bool Classification { get; set; }
    }
}
