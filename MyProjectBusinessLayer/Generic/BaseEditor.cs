using System;
using AutoMapper;
using MyProjectDataLayer.DAL;

namespace MyProjectBusinessLayer.Generic
{
    public abstract class BaseEditor<TModel, TViewModel> : BaseEditor<TModel>, IEditor<TModel, TViewModel>
         where TModel : class where TViewModel : class
    {
        protected BaseEditor(IRepository repository) : base(repository)
        {
        }

        public TViewModel Update(TViewModel source, object id)
        {
            var existingModel = Repository.Find<TModel>(id);
            if (existingModel == null) throw new NullReferenceException(typeof(TModel) + " not found");

            var updatedModel = Update(Mapper.Map(source, existingModel));
            
            return Mapper.Map<TModel,TViewModel>(updatedModel);
        }
    }

    public abstract class BaseEditor<TModel> : IEditor<TModel> where TModel : class
    {
        protected IRepository Repository { get; set; }
        protected BaseEditor(IRepository repository)
        {
            Repository = repository;
        }

        public TModel Update(TModel source)
        {
            var result = Repository.Update(source);
            if (result == null) throw new NullReferenceException("Cannot update model : " + typeof(TModel).FullName);
            Repository.Save();
            return result;
        }
    }
}