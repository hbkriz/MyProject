using System;
using AutoMapper;
using MyProjectDataLayer.DAL;

namespace MyProjectBusinessLayer.Generic
{
    public abstract class BaseCreator<TModel, TViewModel> : BaseCreator<TModel>, ICreator<TModel, TViewModel>
        where TViewModel : class
        where TModel : class
    {
        protected BaseCreator(IRepository repository) : base(repository)
        {
        }

        public virtual TViewModel Create(TViewModel vm)
        {
            var model = Mapper.Map<TViewModel, TModel>(vm);
            return Mapper.Map<TModel, TViewModel>(Create(model));
        }
    }

    public abstract class BaseCreator<TModel> : ICreator<TModel>
        where TModel : class
    {
        protected IRepository Repository { get; set; }
        protected BaseCreator(IRepository repository)
        {
            Repository = repository;
        }

        public virtual TModel Create(TModel model)
        {
            var addedModel = Repository.Add(model);
            Repository.Save();
            return addedModel;
        }
    }
}