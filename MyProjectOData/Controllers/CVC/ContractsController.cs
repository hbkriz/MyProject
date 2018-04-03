using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.DAL;
using MyProjectOData.Models;
using MyProjectOData.Retrievers.ModelRetriever;

namespace MyProjectOData.Controllers.CVC
{
    public class ContractsController : ODataController
    {
        private readonly IContractRetriever _retriever;

        public ContractsController()
        {
            _retriever = new ContractRetriever(new Repository(new UnitOfWork<CostValueCompContext>(new CostValueCompContext())));
        }

        [EnableQuery]
        public IQueryable<Contract> Get()
        {
            return _retriever.GetAll(null).AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Contract> Get(int key)
        {
            var result = _retriever.GetAll(p => p.ContractId == key).AsQueryable();
            return SingleResult.Create(result);
        }

    }
}
