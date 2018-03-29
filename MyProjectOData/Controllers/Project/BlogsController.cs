using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.DAL;
using MyProjectOData.Models;
using MyProjectOData.Retrievers;
using MyProjectOData.Retrievers.ModelRetriever;

namespace MyProjectOData.Controllers.Project
{
    //To expand results in client side ($expand) use Posts($select=Title;$expand=TypeOfPosts($select=Type))
    //To select results in client side ($select) use Title
    public class BlogsController : ODataController
    {
        private readonly IBlogRetriever _retriever;

        public BlogsController()
        {
            _retriever = new BlogRetriever(new Repository(new UnitOfWork(new ProjectContext())));
        }
        
        [EnableQuery]
        public IQueryable<Blog> Get()
        {
            return _retriever.GetAll(null).AsQueryable();
        }
        

        [EnableQuery]
        public SingleResult<Blog> Get([FromODataUri] int key)
        {
            var result = _retriever.GetAll(p => p.BlogId == key).AsQueryable();
            return SingleResult.Create(result);
        }
    }
}
