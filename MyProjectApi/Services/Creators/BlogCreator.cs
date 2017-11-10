using MyProjectApi.DAL;
using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.Services.Creators.Interfaces;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services.Creators
{
    public class BlogCreator : BaseCreator<Blog, BlogViewModel>, IBlogCreator
    {
        public BlogCreator(IRepository repository) : base(repository) { }
    }
}