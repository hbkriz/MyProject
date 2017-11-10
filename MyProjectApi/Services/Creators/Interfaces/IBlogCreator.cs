using MyProjectApi.Generic;
using MyProjectApi.Models;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services.Creators.Interfaces
{
    public interface IBlogCreator : ICreator<Blog, BlogViewModel>
    {
    }
}