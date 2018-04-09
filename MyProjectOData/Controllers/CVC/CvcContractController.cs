using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using MyProjectOData.DAL;
using MyProjectOData.DAL.Contexts;
using MyProjectOData.Models.CVC;
using MyProjectOData.Retrievers.CVC;

namespace MyProjectOData.Controllers.CVC
{
    public class CvcContractController : ODataController
    {
        private readonly IContractRetriever _retriever;

        public CvcContractController()
        {
            _retriever = new ContractRetriever(new Repository(new UnitOfWork<CvcContext>(new CvcContext())));
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
