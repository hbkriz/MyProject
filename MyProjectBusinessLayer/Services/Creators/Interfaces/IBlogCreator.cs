using MyProjectBusinessLayer.Generic;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.Models;

namespace MyProjectBusinessLayer.Services.Creators.Interfaces
{
    public interface IBlogCreator : ICreator<Blog, BlogViewModel>
    {
    }
}