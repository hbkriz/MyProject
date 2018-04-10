using System.Linq;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.Models.Test;
using MyProjectOData.Retrievers.Test;

namespace MyProjectOData.Controllers.Test
{
    public class ProductsController : ODataController
    {
        private readonly TestDataService _service = new TestDataService();

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return _service.Products;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_service.Products.Where(c => c.Id == key));
        }
    }
}
