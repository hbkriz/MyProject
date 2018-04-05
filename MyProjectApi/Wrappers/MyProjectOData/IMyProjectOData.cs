using System.Collections.Generic;
using System.Threading.Tasks;
using MyProjectApi.DTOs;

namespace MyProjectApi.Wrappers.MyProjectOData
{
    public interface IMyProjectOData
    {
        Task<IEnumerable<BlogDto>> GetAllBlogs();
        Task<BlogDto> GetBlog(string contractNumber);
    }
}