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
    public class ClientInvoicingClientController : ODataController
    {
        private readonly IClientRetriever _retriever;

        public ClientInvoicingClientController()
        {
            _retriever = new ClientRetriever(new Repository(new UnitOfWork<ClientInvoiceContext>(new ClientInvoiceContext())));
        }

        [EnableQuery]
        public IQueryable<Client> Get()
        {
            return _retriever.GetAll(null).AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Client> Get(int key)
        {
            var result = _retriever.GetAll(p => p.ContractId == key).AsQueryable();
            return SingleResult.Create(result);
        }

    }
}
