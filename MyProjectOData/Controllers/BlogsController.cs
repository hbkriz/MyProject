using System.Linq;
using System.Web.Http;
using System.Web.OData;
using MyProjectDataLayer.DAL;
using MyProjectDataLayer.Models;

namespace MyProjectOData.Controllers
{
    public class BlogsController : ODataController
    {
        Context db = new Context();

        [EnableQuery]
        public IQueryable<Blog> Get()
        {
            return db.Blogs;
        }
        

        [EnableQuery]
        public SingleResult<Blog> Get([FromODataUri] int key)
        {
            IQueryable<Blog> result = db.Blogs.Where(p => p.BlogId == key);
            return SingleResult.Create(result);
        }
    }
}
