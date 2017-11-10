using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services.Editors.Interfaces
{
    public interface IBlogEditor : IEditor<Blog, BlogViewModel>
    {
    }
}