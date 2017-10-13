using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyProjectApi.DAL;
using MyProjectApi.Models;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Controllers
{
    public class BlogController : ApiController
    {
        private readonly IService<Blog> _blogService;

        public BlogController(IService<Blog> blogService)
        {
            //_blogService = new Service<Blog>(new UnitOfWork(new Context()));
            _blogService = blogService;
        }

        public IEnumerable<BlogViewModel> GetAll()
        {
            return _blogService.GetAll()
                .Select(e => new BlogViewModel
                {
                    Name = e.Name
                });
        }

        public BlogViewModel Get(int id)
        {
            var blog = _blogService.Get(i => i.BlogId == id);

            return new BlogViewModel
            {
                Name = blog.Name
            };
        }

        public void Delete(int id)
        {
            var blog = _blogService.Get(i => i.BlogId == id);
            _blogService.Delete(blog);
        }
    }
}
