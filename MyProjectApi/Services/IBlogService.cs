using System.Collections.Generic;
using MyProjectApi.Models;

namespace MyProjectApi.Services
{
    public interface IBlogService
    {
        IList<Blog> AllBlogs();
    }
}