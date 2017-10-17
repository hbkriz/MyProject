using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using MyProjectApi.DAL;
using MyProjectApi.Models;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<BlogViewModel> GetAll()
        {
            var models = _unitOfWork.GetAll<Blog>();
            var viewModels = models.Select(e => new BlogViewModel
                {
                    Name = e.Name
                });
            return viewModels.ToList();
        }

        public BlogViewModel Get(int id)
        {
            var model =_unitOfWork.Get<Blog>(i => i.BlogId == id);
            if (model == null) throw new NullReferenceException("Id not found");
            return new BlogViewModel
            {
                Name = model.Name
            };
        }

        public void Delete(int id)
        {
            var model = _unitOfWork.Get<Blog>(i => i.BlogId == id);
            if (model == null) throw new NullReferenceException("Id not found");
            _unitOfWork.Delete(model);
            _unitOfWork.Save();
        }

        public BlogViewModel Add(BlogViewModel viewModel)
        {
            var model = new Blog
            {
                Name = viewModel.Name
            };
            var newResult = _unitOfWork.Add(model);
            _unitOfWork.Save();
            return new BlogViewModel
            {
                Name = newResult.Name
            };
        }

        public BlogViewModel Put(int id, BlogViewModel viewModel)
        {
            var model = _unitOfWork.Get<Blog>(i => i.BlogId == id);
            if (model == null) throw new NullReferenceException("Id not found");
            model.Name = viewModel.Name;

            var updatedResult = _unitOfWork.Update(model);
            _unitOfWork.Save();
            return new BlogViewModel
            {
                Name = updatedResult.Name
            };
        }

    }
}