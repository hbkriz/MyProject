using System.Collections.Generic;
using System.Linq;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Helpers.Interfaces
{
    public interface IBlogService
    {
        IList<BlogViewModel> GetAll();
        IQueryable<Blog> GetAllBlogs();
        BlogViewModel Get(int id);
        Blog GetBlog(int id);
        void Delete(int id);
        BlogViewModel Add(BlogViewModel viewModel);
        BlogViewModel Put(BlogViewModel viewModel, int id);
    }
}