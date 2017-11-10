using System.Collections.Generic;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Helpers.Interfaces
{
    public interface IBlogService
    {
        IList<BlogViewModel> GetAll();
        BlogViewModel Get(int id);
        void Delete(int id);
        BlogViewModel Add(BlogViewModel viewModel);
        BlogViewModel Put(BlogViewModel viewModel, int id);
    }
}