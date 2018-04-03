using MyProjectOData.DAL;
using MyProjectOData.Models.ClientInvoicing;

namespace MyProjectOData.Retrievers.ClientInvoicing
{
    public class ClientRetriever: BaseRetriever<Client>, IClientRetriever
    {
        public ClientRetriever(IRepository repository) : base(repository) { }
    }
}