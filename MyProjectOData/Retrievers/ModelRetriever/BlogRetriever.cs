using MyProjectOData.DAL;
using MyProjectOData.Models;

namespace MyProjectOData.Retrievers.ModelRetriever
{
    public class BlogRetriever :BaseRetriever<Blog>, IBlogRetriever
    {
        public BlogRetriever(IRepository repository): base(repository) { }
    }
}