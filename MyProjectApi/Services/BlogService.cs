using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProjectApi.DAL;
using MyProjectApi.Models;

namespace MyProjectApi.Services
{
    public class BlogService : Service<Blog>
    {
        public BlogService(IUnitOfWork unitOfWork) : base(unitOfWork){}

        public new void Update(Blog blog)
        {
            base.Update(blog);
        }
    }
}