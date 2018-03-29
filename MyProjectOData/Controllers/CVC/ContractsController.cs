using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.DAL;
using MyProjectOData.Models;

namespace MyProjectOData.Controllers.CVC
{
    public class ContractsController : ODataController
    {
        CVCContext _cvcContext = new CVCContext();

        [EnableQuery]
        public IQueryable<Contract> Get()
        {
            return _cvcContext.Contracts;
        }

        [EnableQuery]
        public SingleResult<Contract> Get(int key)
        {
            var result = _cvcContext.Contracts.Where(p => p.ContractId == key);
            return SingleResult.Create(result);
        }

    }
}
