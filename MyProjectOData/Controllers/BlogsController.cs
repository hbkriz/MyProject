using System.Linq;
using System.Web.Http;
using System.Web.OData;
using MyProjectBusinessLayer.Services.Retrievers;
using MyProjectBusinessLayer.Services.Retrievers.Interfaces;
using MyProjectDataLayer.DAL;
using MyProjectDataLayer.Models;

namespace MyProjectOData.Controllers
{
    //To expand results in client side ($expand) use Posts($select=Title;$expand=TypeOfPosts($select=Type))
    //To select results in client side ($select) use Title
    public class BlogsController : ODataController
    {
        private readonly IBlogRetriever _retriever;

        public BlogsController()
        {
            _retriever = new BlogRetriever(new Repository(new Context()));
        }
        
        [EnableQuery(MaxExpansionDepth = 4)]
        public IQueryable<Blog> Get()
        {
            return _retriever.GetAllModels(null).AsQueryable();
        }
        

        [EnableQuery]
        public SingleResult<Blog> Get([FromODataUri] int key)
        {
            var result = _retriever.GetAllModels(p => p.BlogId == key).AsQueryable();
            return SingleResult.Create(result);
        }
    }
}
