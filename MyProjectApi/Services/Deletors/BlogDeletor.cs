using MyProjectApi.DAL;
using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.Services.Deletors.Interfaces;

namespace MyProjectApi.Services.Deletors
{
    public class BlogDeletor : BaseDeletor<Blog>, IBlogDeletor
    {
        public BlogDeletor(IRepository repository) : base(repository) { }
    }
}