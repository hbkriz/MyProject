using System.Collections.Generic;
using System.Web.Http;
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
            return _blogService.GetAll();
        }

        public BlogViewModel Get(int id)
        {
            return _blogService.Get(id);
        }

        //public void Delete(int id)
        //{
        //    _blogService.Delete(id);
        //}

        //public BlogViewModel Put(int id, BlogViewModel viewModel)
        //{
        //    return _blogService.Put(id,viewModel);
        //}

        //public BlogViewModel Create(BlogViewModel viewModel)
        //{
        //    return _blogService.Add(viewModel);
        //}
    }
}
