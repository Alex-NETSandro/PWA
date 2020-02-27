using Blog.Models.Author;
using Blog.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Post
{
    public class PostEntity
    {
        public string Title { get; set; }
        public AuthorEntity AuthorEntity { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
    }
}
