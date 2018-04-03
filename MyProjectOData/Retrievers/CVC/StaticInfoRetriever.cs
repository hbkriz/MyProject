using MyProjectOData.DAL;
using MyProjectOData.Models.CVC;

namespace MyProjectOData.Retrievers.CVC
{
    public class StaticInfoRetriever : BaseRetriever<StaticInfo>, IStaticInfoRetriever
    {
        public StaticInfoRetriever(IRepository repository) : base(repository) { }
    }
}