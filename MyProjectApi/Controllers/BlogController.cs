using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyProjectApi.DAL;
using MyProjectApi.Models;
using MyProjectApi.Services;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Controllers
{
    public class BlogController : ApiController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            //_blogService = new Service<Blog>(new UnitOfWork(new Context()));
            _blogService = blogService;
        }

        public IEnumerable<BlogViewModel> GetAll()
        {
            return _blogService.AllBlogs()
                .Select(e => new BlogViewModel
                {
                    Name = e.Name
                });
        }

        //public BlogViewModel Get(int id)
        //{
        //    var blog = _blogService.Get(i => i.BlogId == id);

        //    return new BlogViewModel
        //    {
        //        Name = blog.Name
        //    };
        //}

        //public void Delete(int id)
        //{
        //    var blog = _blogService.Get(i => i.BlogId == id);
        //    _blogService.Delete(blog);

        //    _blogService.Save();
        //}

        //public BlogViewModel Put(int id, BlogViewModel viewModel)
        //{
        //    var blog = _blogService.Get(i => i.BlogId == id);
        //    blog.Name = viewModel.Name;

        //    var updatedResult = _blogService.Update(blog);
        //    _blogService.Save();
        //    return new BlogViewModel
        //    {
        //        Name = updatedResult.Name
        //    };
        //}

        //public BlogViewModel Create(BlogViewModel viewModel)
        //{
        //    var blog = new Blog
        //    {
        //        Name = viewModel.Name
        //    };
        //    var newResult = _blogService.Create(blog);
        //    _blogService.Save();
        //    return new BlogViewModel
        //    {
        //        Name = newResult.Name
        //    };
        //}
    }
}
