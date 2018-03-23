using MyProjectBusinessLayer.Generic;
using MyProjectBusinessLayer.Services.Deletors.Interfaces;
using MyProjectDataLayer.DAL;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Services.Deletors
{
    public class BlogDeletor : BaseDeletor<Blog>, IBlogDeletor
    {
        public BlogDeletor(IRepository repository) : base(repository) { }
    }
}