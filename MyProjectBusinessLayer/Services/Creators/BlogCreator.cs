using MyProjectBusinessLayer.Generic;
using MyProjectBusinessLayer.Services.Creators.Interfaces;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.DAL;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Services.Creators
{
    public class BlogCreator : BaseCreator<Blog, BlogViewModel>, IBlogCreator
    {
        public BlogCreator(IRepository repository) : base(repository) { }
    }
}