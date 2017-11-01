using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.DTOs;

namespace MyProject.Wrappers.MyProjectApi
{
    public interface IMyProjectApi
    {
        Task<IEnumerable<BlogDto>> GetAllBlogs();
    }
}