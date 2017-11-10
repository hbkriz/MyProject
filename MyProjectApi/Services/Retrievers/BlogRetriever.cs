using MyProjectApi.DAL;
using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.Services.Retrievers.Interfaces;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services.Retrievers
{
    public class BlogRetriever :BaseRetriever<Blog, BlogViewModel>, IBlogRetriever
    {
        public BlogRetriever(IRepository repository): base(repository) { }
    }
}