using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.DAL;
using MyProjectOData.DAL.Contexts;
using MyProjectOData.Models;
using MyProjectOData.Models.CVC;
using MyProjectOData.Retrievers.CVC;

namespace MyProjectOData.Controllers.CVC
{
    public class CvcContractsController : ODataController
    {
        private readonly IContractRetriever _retriever;

        public CvcContractsController()
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
