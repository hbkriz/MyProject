using System.Collections.Generic;
using System.Web.Http;
using MyProjectBusinessLayer.Helpers.Interfaces;
using MyProjectBusinessLayer.ViewModels;

namespace MyProjectApi.Controllers
{
    [RoutePrefix("api/Blog")]
    public class BlogController : ApiController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Route("GetAll")]
        public IEnumerable<BlogViewModel> GetAll()
        {
            return _blogService.GetAll();
        }

        [Route("Get")]
        public BlogViewModel Get(int id)
        {
            return _blogService.Get(id);
        }

        [Route("Delete")]
        public void Delete(int id)
        {
            _blogService.Delete(id);
        }

        [Route("Update")]
        public BlogViewModel Put(int id, BlogViewModel viewModel)
        {
            return _blogService.Put(viewModel, id);
        }

        [Route("Create")]
        public BlogViewModel Create(BlogViewModel viewModel)
        {
            return _blogService.Add(viewModel);
        }
    }
}
