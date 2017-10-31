using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyProjectApi.DAL;
using MyProjectApi.Models;
using MyProjectApi.ViewModels;

namespace MyProjectApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _repository;

        public BlogService(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public IList<BlogViewModel> GetAll()
        {
            var models = _repository.GetAll().ToList();
            return Mapper.Map<List<BlogViewModel>>(models);
        }

        public BlogViewModel Get(int id)
        {
            var model = _repository.Get(i => i.BlogId == id);
            if (model == null) throw new NullReferenceException("Id not found");
            return Mapper.Map<BlogViewModel>(model);
        }

        //public void Delete(int id)
        //{
        //    _unitOfWork.Delete<Blog>(i => i.BlogId == id);
        //    _unitOfWork.Save();
        //}

        //public BlogViewModel Add(BlogViewModel viewModel)
        //{
        //    var newResult = _unitOfWork.Add(Mapper.Map<Blog>(viewModel));
        //    _unitOfWork.Save();
        //    return Mapper.Map<BlogViewModel>(newResult);
        //}

        //public BlogViewModel Put(int id, BlogViewModel viewModel)
        //{
        //    var model = _unitOfWork.Get<Blog>(i => i.BlogId == id);
        //    if (model == null) throw new NullReferenceException("Id not found");
        //    var updatedModel = Mapper.Map(viewModel, model);
        //    var updatedResult = _unitOfWork.Update(updatedModel, updatedModel.BlogId);
        //    _unitOfWork.Save();
        //    return Mapper.Map<BlogViewModel>(updatedResult);
        //}

    }
}