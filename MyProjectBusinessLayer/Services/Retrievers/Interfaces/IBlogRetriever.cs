using MyProjectBusinessLayer.Generic;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Services.Retrievers.Interfaces
{
    public interface IBlogRetriever : IRetriever<Blog, BlogViewModel>
    {
        
    }
}