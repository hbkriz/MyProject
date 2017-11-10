using MyProjectApi.DAL;
using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.Services.Editors.Interfaces;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services.Editors
{
    public class BlogEditor : BaseEditor<Blog, BlogViewModel>, IBlogEditor
    {
        public BlogEditor(IRepository repository) : base(repository) { }
    }
}