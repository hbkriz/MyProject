using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.DTOs
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public virtual List<PostDto> Posts { get; set; }
    }
}