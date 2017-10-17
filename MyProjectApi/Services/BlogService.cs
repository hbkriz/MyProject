using System.Collections.Generic;
using System.Linq;
using MyProjectApi.DAL;
using MyProjectApi.Models;

namespace MyProjectApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Blog> AllBlogs()
        {
            return _unitOfWork.GetAll<Blog>().ToList();
        }
    }
}