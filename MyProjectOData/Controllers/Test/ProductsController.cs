using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.Models;

namespace MyProjectOData.Controllers.Test
{
    public class ProductsController : ODataController
    {
        private readonly DataService _service = new DataService();

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
