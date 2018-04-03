using MyProjectOData.DAL;
using MyProjectOData.Models.ClientInvoicing;

namespace MyProjectOData.Retrievers.ClientInvoicing
{
    public class ContractRetriever : BaseRetriever<Contract>, IContractRetriever
    {
        public ContractRetriever(IRepository repository) : base(repository) { }
    }
}