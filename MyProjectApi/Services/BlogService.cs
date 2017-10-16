using MyProjectApi.DAL;
using MyProjectApi.Models;

namespace MyProjectApi.Services
{
    public class BlogService : Service<Blog>
    {
        public BlogService(IUnitOfWork unitOfWork) : base(unitOfWork){}
        //TODO: If anything different needs to be done other than CRUD
    }
}