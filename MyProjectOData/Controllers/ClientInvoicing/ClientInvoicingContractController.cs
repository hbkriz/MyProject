using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using MyProjectOData.DAL;
using MyProjectOData.DAL.Contexts;
using MyProjectOData.Models.ClientInvoicing;
using MyProjectOData.Retrievers.ClientInvoicing;

namespace MyProjectOData.Controllers.ClientInvoicing
{
    public class ClientInvoicingContractController : ODataController
    {
        private readonly IContractRetriever _retriever;

        public ClientInvoicingContractController()
        {
            _retriever = new ContractRetriever(new Repository(new BaseContext<ClientInvoiceContext>(new ClientInvoiceContext())));
        }

        [EnableQuery(MaxExpansionDepth = 3)]
        public IHttpActionResult Get()
        {
            return Ok(_retriever.GetAll(null));
        }

        [EnableQuery]
        public IHttpActionResult Get(string key)
        {
            var result = _retriever.GetAll(p => p.ContractReference == key);
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetCircles(string key)
        {
            return Ok(1);
        }

        [HttpGet]
        public IHttpActionResult GetTriangles()
        {
            return Ok(3);
        }
    }
}
