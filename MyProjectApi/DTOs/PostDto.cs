﻿namespace MyProjectApi.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual BlogDto Blog { get; set; }
    }
}