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
        private readonly IRepository _repository;
        
        public BlogService(IRepository repository)
        {
            _repository = repository;
        }

        public IList<BlogViewModel> GetAll()
        {
            var models = _repository.GetAll<Blog>().ToList();
            return Mapper.Map<List<BlogViewModel>>(models);
        }

        public BlogViewModel Get(int id)
        {
            var model = _repository.Get<Blog>(i => i.BlogId == id);
            if (model == null) throw new NullReferenceException("Id not found");
            return Mapper.Map<BlogViewModel>(model);
        }

        public void Delete(int id)
        {
            _repository.Delete<Blog>(i => i.BlogId == id);
            _repository.Save();
        }

        public BlogViewModel Add(BlogViewModel viewModel)
        {
            var newResult = _repository.Add(Mapper.Map<Blog>(viewModel));
            _repository.Save();
            return Mapper.Map<BlogViewModel>(newResult);
        }

        public BlogViewModel Put(int id, BlogViewModel viewModel)
        {
            var model = _repository.Get<Blog>(i => i.BlogId == id);
            if (model == null) throw new NullReferenceException("Id not found");
            var updatedModel = Mapper.Map(viewModel, model);
            var updatedResult = _repository.Update(updatedModel);
            _repository.Save();
            return Mapper.Map<BlogViewModel>(updatedResult);
        }

    }
}