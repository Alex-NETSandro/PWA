using Blog.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Post.Review.Comment
{
    public class CommentEntity
    {
        public ReviewEntity ReviewEntity { get; set; }
        public string Text { get; set; }
        public AuthorEntity AuthorEntity { get; set; }
    }
}
