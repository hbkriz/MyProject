using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
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
            _retriever = new ContractRetriever(new Repository(new UnitOfWork<ClientInvoiceContext>(new ClientInvoiceContext())));
        }

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(_retriever.GetAll(null).AsQueryable());
        }

        [EnableQuery]
        public IHttpActionResult Get(int key)
        {
            var result = _retriever.GetAll(p => p.ContractId == key).AsQueryable();
            return Ok(result);
        }
    }
}
