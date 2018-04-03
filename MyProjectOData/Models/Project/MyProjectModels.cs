using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProjectOData.Models.Project
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<SocialMedia> SocialMedias { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual List<TypeOfPost> TypeOfPosts { get; set; }
    }

    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class TypeOfPost
    {
        public int TypeOfPostId { get; set; }
        public string Type { get; set; }
        
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}