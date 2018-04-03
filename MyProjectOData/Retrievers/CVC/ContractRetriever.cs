using MyProjectOData.DAL;
using MyProjectOData.Models;
using MyProjectOData.Models.CVC;

namespace MyProjectOData.Retrievers.CVC
{
    public class ContractRetriever: BaseRetriever<Contract>, IContractRetriever
    {
        public ContractRetriever(IRepository repository) : base(repository) { }
    }
}