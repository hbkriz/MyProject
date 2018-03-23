using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using MyProjectDataLayer.DAL;

namespace MyProjectBusinessLayer.Generic
{
    public abstract class BaseRetriever<TModel, TViewModel> : BaseRetriever<TModel>, IRetriever<TModel, TViewModel>
        where TModel : class
        where TViewModel : class
    {
        protected BaseRetriever(IRepository repository) : base(repository)
        {
        }
        
        public new virtual TViewModel Get(Expression<Func<TModel, bool>> match)
        {
            return Mapper.Map<TViewModel>(base.Get(match));
        }
        
        public new virtual IEnumerable<TViewModel> GetAll(Expression<Func<TModel, bool>> match)
        {
            return Mapper.Map<IEnumerable<TViewModel>>(base.GetAll(match));
        }
        
        public virtual TModel GetModel(Expression<Func<TModel, bool>> match)
        {
            return base.Get(match);
        }

        public virtual IEnumerable<TModel> GetAllModels(Expression<Func<TModel, bool>> match)
        {
            return base.GetAll(match);
        }
    }

    public abstract class BaseRetriever<TModel> : IRetriever<TModel>
        where TModel : class
    {
        protected IRepository Repository { get; set; }
        protected BaseRetriever(IRepository repository)
        {
            Repository = repository;
        }

        public virtual TModel Get(Expression<Func<TModel, bool>> match)
        {
            return Repository.Get(match);
        }

        public virtual IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> match)
        {
            return Repository.GetAll(match);
        }
    }
}
