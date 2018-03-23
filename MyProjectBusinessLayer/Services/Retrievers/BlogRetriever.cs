using MyProjectBusinessLayer.Generic;
using MyProjectBusinessLayer.Services.Retrievers.Interfaces;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.DAL;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Services.Retrievers
{
    public class BlogRetriever :BaseRetriever<Blog, BlogViewModel>, IBlogRetriever
    {
        public BlogRetriever(IRepository repository): base(repository) { }
    }
}