using MyProjectOData.DAL;
using MyProjectOData.Models;
using MyProjectOData.Models.Project;

namespace MyProjectOData.Retrievers.Project
{
    public class BlogRetriever :BaseRetriever<Blog>, IBlogRetriever
    {
        public BlogRetriever(IRepository repository): base(repository) { }
    }
}