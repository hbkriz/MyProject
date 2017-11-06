using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.DTOs;

namespace MyProject.Wrappers.MyProjectApi
{
    public interface IMyProjectApi
    {
        Task<IEnumerable<BlogDto>> GetAllBlogs();
        Task<BlogDto> GetBlog(int id);
        Task DeleteBlog(int id);
        Task<BlogDto> CreateBlog(BlogDto blog);
        Task<BlogDto> UpdateBlog(int id, BlogDto blog);
    }
}