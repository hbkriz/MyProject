using System.Collections.Generic;

namespace MyProjectApi.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class Todo
    {
        public int TodoId { get; set; }
        public string Comment { get; set; }
    }

    public class Name
    {
        public int NameId { get; set; }
        public string Value { get; set; }
    }

    public class ShallNotHaveName
    {
        public int ShallNotHaveNameId { get; set; }
        public string Value { get; set; }
    }

}