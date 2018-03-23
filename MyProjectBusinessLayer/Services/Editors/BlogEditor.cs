using MyProjectBusinessLayer.Generic;
using MyProjectBusinessLayer.Services.Editors.Interfaces;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.DAL;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Services.Editors
{
    public class BlogEditor : BaseEditor<Blog, BlogViewModel>, IBlogEditor
    {
        public BlogEditor(IRepository repository) : base(repository) { }
    }
}