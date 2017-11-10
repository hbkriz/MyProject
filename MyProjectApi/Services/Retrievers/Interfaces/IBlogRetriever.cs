using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services.Retrievers.Interfaces
{
    public interface IBlogRetriever : IRetriever<Blog, BlogViewModel>
    {
        
    }
}