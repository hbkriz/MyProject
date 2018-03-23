using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.Business;
using MyProjectOData.Models;

namespace MyProjectOData.Controllers
{
    public class ProductsController : ODataController
    {
        [EnableQuery]
        public IList<Product> Get()
        {
            return p_service.Products;
        }

        public Product Get(int key)
        {
            IEnumerable<Product> product = p_service.Products.Where(m => m.Id == key);
            if (product.Count() == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return product.FirstOrDefault();
        }



        private ProductService p_service = new ProductService();
    }
}
