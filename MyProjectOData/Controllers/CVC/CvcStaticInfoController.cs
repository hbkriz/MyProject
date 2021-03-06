﻿using System.Linq;
using System.Web.Http;
using System.Web.OData;
using MyProjectOData.DAL;
using MyProjectOData.DAL.Contexts;
using MyProjectOData.Models.CVC;
using MyProjectOData.Retrievers.CVC;

namespace MyProjectOData.Controllers.CVC
{
    public class CvcStaticInfoController : ODataController
    {
        private readonly IStaticInfoRetriever _staticInfoRetriever;

        public CvcStaticInfoController()
        {
            _staticInfoRetriever = new StaticInfoRetriever(new Repository(new BaseContext<CvcContext>(new CvcContext())));
        }

        [EnableQuery]
        public IQueryable<StaticInfo> Get()
        {
            return _staticInfoRetriever.GetAll(null);
        }

        [EnableQuery]
        public SingleResult<StaticInfo> Get(int key)
        {
            var result = _staticInfoRetriever.GetAll(p => p.ContractId == key);
            return SingleResult.Create(result);
        }
    }
}
