using MyProjectOData.DAL;
using MyProjectOData.Models;

namespace MyProjectOData.Retrievers.ModelRetriever
{
    public class ContractRetriever: BaseRetriever<Contract>, IContractRetriever
    {
        public ContractRetriever(IRepository repository) : base(repository) { }
    }
}