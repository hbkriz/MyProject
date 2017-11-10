using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using MyProjectApi.DAL;

namespace MyProjectApi.Generic
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
        
        public new virtual IList<TViewModel> GetAll(Expression<Func<TModel, bool>> match)
        {
            return Mapper.Map<IList<TViewModel>>(base.GetAll(match));
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

        public virtual IList<TModel> GetAll(Expression<Func<TModel, bool>> match)
        {
            return Repository.GetAll(match).ToList();
        }
    }
}
